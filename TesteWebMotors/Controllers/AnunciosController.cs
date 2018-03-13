using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
using Newtonsoft.Json;

namespace TesteWebMotors.Controllers
{
    public class AnunciosController : Controller
    {

        public ActionResult Index()
        {
            AnuncioBLL bll = new AnuncioBLL();
            return View(bll.BuscarAnuncios());
        }


        public ActionResult Create()
        {
            string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make";
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url).GetAwaiter().GetResult();
            var marcas = JsonConvert.DeserializeObject<List<Models.Marca>>(response);
            Models.Anuncio anuncio = new Models.Anuncio();
            anuncio.Marcas = new List<Models.Marca>();
            anuncio.Marcas.Add(new Models.Marca() { Id = 0, Name = "Selecione" });
            anuncio.Marcas = marcas;

            return View(anuncio);
        }

        public JsonResult CarregarModelo(int IdMarca) {

            string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=" + IdMarca.ToString();

            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url).GetAwaiter().GetResult();
            var modelos = JsonConvert.DeserializeObject<List<Models.Modelo>>(response);
            return Json(modelos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarregarVersao(int IdModelo)
        {
            string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=" + IdModelo.ToString();
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url).GetAwaiter().GetResult();
            var versao = JsonConvert.DeserializeObject<List<Models.Versao>>(response);
            return Json(versao, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Models.Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                DTO.Anuncio anuncioDTO = new DTO.Anuncio();
                anuncioDTO.Ano = anuncio.Ano;
                anuncioDTO.Marca = anuncio.Marca;
                anuncioDTO.Modelo = anuncio.Modelo;
                anuncioDTO.Observacao = anuncio.Observacao;
                anuncioDTO.Quilometragem = anuncio.Quilometragem;
                anuncioDTO.Versao = anuncio.Versao;

                AnuncioBLL bll = new AnuncioBLL();
                bll.InserirAnuncio(anuncioDTO);
                //Está salvando o ID ao invés do Nome da Marca, Modelo e versão :(
                //Fazer o post por AJAX passando o text dos dropdowns.
                return RedirectToAction("Index");
            }

            return View(anuncio);
        }
    }
}
