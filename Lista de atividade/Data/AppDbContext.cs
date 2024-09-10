using Lista_de_atividade.Models;
using Microsoft.EntityFrameworkCore;
namespace Lista_de_atividade.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Status> Statuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaID = "trabalho", NomeId = "Trabalho" },
                new Categoria { CategoriaID = "casa", NomeId = "Casa" },
                new Categoria { CategoriaID = "faculdade", NomeId = "Faculdade" },
                new Categoria { CategoriaID = "compras", NomeId = "Compras" },
                new Categoria { CategoriaID = "academia", NomeId = "Academia" }
                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "aberto", NomeId = "Aberto" },
                new Status { StatusId = "completo", NomeId = "Completo" }

                    );





            base.OnModelCreating(modelBuilder);
        }
    }
}
