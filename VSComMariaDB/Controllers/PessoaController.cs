using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Pegar a lista de todas as pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Pessoa> GetLista()
        {
            var _DbContext = new _DbContext();
            var vLista = _DbContext.Pessoa.ToList();

            return vLista;
        }
        /// <summary>
        /// Pegar os dados de uma pessoa específica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("id")]

        public Pessoa  GetPessoa(int id)
        {
            //Intanciar o banco de dados
            var _DbContext =new _DbContext();

            //selecionar a pessoa pelo id
            /*var vPessoa = _DbContext.Pessoa
                .Where(p => p.Id == id)    
                .FirstOrDefault();*/

            var vPessoa = _DbContext.Pessoa.Find(id);

            //retornar dos dados
            return vPessoa;
        }

        [HttpPost]
        public Pessoa Inserir(Pessoa pessoa)
        {
            var _DbContext = new _DbContext();

            _DbContext.Pessoa.Add(pessoa);
            _DbContext.SaveChanges();

            return pessoa;
        }

        [HttpPut]
        public Pessoa Alterar(Pessoa pessoa)
        {
            var _DbContext = new _DbContext();

            _DbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
            _DbContext.SaveChanges();

            return pessoa;
        }

        [HttpDelete]

        public ActionResult Remove(int id)
        {
            // Instanciar o banco de dados
            var _Dbcontext = new _DbContext();
            // localizar o registro a ser removido pelo id

            var vPessoa = _Dbcontext.Pessoa.Find(id);
            //Remover o registro encontro
            _Dbcontext.Pessoa.Remove(vPessoa);
            //salvar alterações
            _Dbcontext.SaveChanges();


            return Ok();
        }

    }
}
