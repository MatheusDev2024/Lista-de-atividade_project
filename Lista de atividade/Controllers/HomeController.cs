using Lista_de_atividade.Data;
using Lista_de_atividade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lista_de_atividade.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string id)
        {

            var filtros = new Filtros(id);

            ViewBag.Filtro = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.VencimentoValores = Filtros.VencimentoValoresFiltro;
            IQueryable<Tarefa> consulta = _context.Tarefas
                .Include(c => c.Categoria) // Problema aqui
                .Include(c => c.Status);

            if (filtros.TemCategoria)
            {
                consulta = consulta.Where(t => t.CategoriaId == filtros.CategoriaId);
            }

            if (filtros.TemStatus)
            {
                consulta = consulta.Where(t => t.StatusId == filtros.StatusId);
            }

            if (filtros.TemVencimento)
            {
                var hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(t => t.DataDeVencimento < hoje);
                }

                if (filtros.EFuturo)
                {
                    consulta = consulta.Where(t => t.DataDeVencimento > hoje);
                }

                if (filtros.EHoje)
                {
                    consulta = consulta.Where(t => t.DataDeVencimento == hoje);
                }
            }


            var tarefas = consulta.OrderBy(t => t.DataDeVencimento).ToList();



            return View(tarefas);
        }


        public IActionResult Adicionar()
        {
            ViewBag.Categoria = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();


            var tarefa = new Tarefa { StatusId = "aberto" };

            return View(tarefa);
        }


        [HttpPost]
        public IActionResult Filtrar(string[] filtro)
        {
            string id = string.Join('-', filtro);
            return RedirectToAction("Index", new { ID = id });
        }


        [HttpPost]
        public IActionResult MarcarCompleto([FromRoute] string id, Tarefa tarefaSelecionada)
        {

            tarefaSelecionada = _context.Tarefas.Find(tarefaSelecionada.Id);

            if (tarefaSelecionada != null)
            {
                tarefaSelecionada.StatusId = "completo";
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { ID = id });


        }
        [HttpPost]
        public IActionResult Adicionar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categoria = _context.Categorias.ToList();
                ViewBag.Status = _context.Statuses.ToList();

                return View(tarefa);
            }

        }
        [HttpPost]
        public IActionResult DeletarCompletos(string id)
        {
            var paraDeletar = _context.Tarefas.Where(s => s.StatusId == "completo").ToList();

            foreach (var tarefa in paraDeletar)
            {
                _context.Tarefas.Remove(tarefa);
            }

            _context.SaveChanges();
            return RedirectToAction("Index" ,new {ID = id});
        }
    }
}
        
