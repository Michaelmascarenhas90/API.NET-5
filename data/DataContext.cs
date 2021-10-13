// mostra onde estão os modelos que serão usados, 
// para executar as açoes em Db
using DOTNETAPI.Models;

// import do enity framework
using Microsoft.EntityFrameworkCore;

namespace DOTNETAPI.data
{
    public class DataContext : DbContext // DataContext herda a class que pertence ao enityFramework
    {
        // contrutor do dataContext(recebe o parametro do DbContext <especifica a class criada para db>) : recebe a heraça de options
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        // configura qual model recebe as funções do enityFramework
        // para cada modelo tera um public DbSet<arquivo do model> apelido { get, set}
        public DbSet<Users> user { get; set; }

    }
}

// com isso podemos manusear o sql sem escrever comandos SQL