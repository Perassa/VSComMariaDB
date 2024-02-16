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

        [HttpGet("ListaAsync")]
        public async Task<List<Pessoa>> GetListaAsync()
        {
            var _DbContext = new _DbContext();
            var vLista = await _DbContext.Pessoa.ToListAsync();

            return vLista;
        }


        /// <summary>
        /// Pegar os dados de uma pessoa específica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("id")]

        public async Task<Pessoa>  GetPessoa(int id)
        {
            //Intanciar o banco de dados
            var _DbContext =new _DbContext();

            //selecionar a pessoa pelo id
            /*var vPessoa = _DbContext.Pessoa
                .Where(p => p.Id == id)    
                .FirstOrDefault();*/

            var vPessoa = await _DbContext.Pessoa.FindAsync(id);

            //retornar dos dados
            return vPessoa;
        }

        [HttpPost]
        public async Task<Pessoa> Inserir(Pessoa pessoa)
        {
            var _DbContext = new _DbContext();

           await _DbContext.Pessoa.AddAsync(pessoa);
           await _DbContext.SaveChangesAsync();

            return pessoa;
        }

        [HttpPut]
        public async Task<Pessoa> Alterar(Pessoa pessoa)
        {
            var _DbContext = new _DbContext();

           _DbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
          await _DbContext.SaveChangesAsync();

            return pessoa;
        }

        [HttpDelete]

        public async Task<ActionResult> Remove(int id)
        {
            // Instanciar o banco de dados
            var _Dbcontext = new _DbContext();
            // localizar o registro a ser removido pelo id

            var vPessoa = await _Dbcontext.Pessoa.FindAsync(id);
            //Remover o registro encontro
            _Dbcontext.Pessoa.Remove(vPessoa);
            //salvar alterações
           await _Dbcontext.SaveChangesAsync();


            return Ok();
        }

    }
}
