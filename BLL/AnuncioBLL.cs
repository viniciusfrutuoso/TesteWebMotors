using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class AnuncioBLL
    {
        public List<Anuncio> BuscarAnuncios() {

            return new AnuncioDAL().BuscarAnuncios();

        }

        public int InserirAnuncio(Anuncio anuncio)
        {

            return new AnuncioDAL().InserirAnuncio(anuncio);

        }

    }
}
