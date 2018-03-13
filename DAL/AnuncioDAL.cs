using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Entity;

namespace DAL
{
    public class AnuncioDAL
    {
        private Context db = new Context();

        public List<Anuncio> BuscarAnuncios() {

            return db.Anuncio.ToList();
        }

        public int InserirAnuncio(Anuncio anuncio) {
            db.Anuncio.Add(anuncio);
            return db.SaveChanges();
        }

    }
}
