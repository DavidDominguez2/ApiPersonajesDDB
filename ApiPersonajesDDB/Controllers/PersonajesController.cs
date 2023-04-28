using ApiPersonajesDDB.Models;
using ApiPersonajesDDB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesDDB.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase {

        private RepositoryPersonajes repo;


        public PersonajesController(RepositoryPersonajes repo) {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get() {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id) {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje) {
            await this.repo.InsertPersonajeAsync(personaje.IdPesonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje) {
            await this.repo.UpdatePersonajeAsync(personaje.IdPesonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeletePersonaje(int id) {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }
    }
}
