using ApiPersonajesDDB.Data;
using ApiPersonajesDDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesDDB.Repositories {
    public class RepositoryPersonajes {

        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context) {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync() {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id) {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPesonaje == id);
        }

        public async Task DeletePersonajeAsync(int id) {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task InsertPersonajeAsync(int id, string nombre, string imagen, int idserie) {
            int newid = await this.context.Personajes.AnyAsync() ? await this.context.Personajes.MaxAsync(x => x.IdPesonaje) + 1 : 1;
            Personaje personaje = new Personaje {
                IdPesonaje = newid,
                Nombre = nombre,
                Imagen = imagen,
                IdSerie = idserie

            };
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int id, string nombre, string imagen, int idserie) {
            Personaje personaje = await this.FindPersonajeAsync(id);

            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;

            await this.context.SaveChangesAsync();
        }

    }
}
