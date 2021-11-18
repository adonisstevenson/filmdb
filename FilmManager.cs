using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using filmdb.Models;
using System.Collections.Generic;
using System.Linq;


namespace filmdb{

    public class FilmManager
{
    public FilmManager AddFilm(FilmModel filmModel)
    {   
        using (FilmContext context = new FilmContext()){
            context.Add(filmModel);

            try{
                context.SaveChanges();
                }
            catch{
                filmModel.ID = 0;
                context.SaveChanges();
            }
        }
        
        return this;
    }

    public FilmManager RemoveFilm(int id)
    {   
        using (FilmContext context = new FilmContext()){

            FilmModel film = context.Films.Find(id);
            context.Films.Remove(film);
            context.SaveChanges();
        }
        

        return this;
    }

    public FilmManager UpdateFilm(FilmModel filmModel)
    {
        using (FilmContext context = new FilmContext()){
            context.Films.Update(filmModel);
            context.SaveChanges();
        }

        return this;
    }

    public FilmManager ChangeTitle(int id, string newTitle)
    {
        using(FilmContext context = new FilmContext()){
            FilmModel film = context.Films.Find(id);

            if (newTitle == null){
                newTitle = "Brak tytułu";
            }

            film.Title = newTitle;
            context.SaveChanges();
        }

        return this;
    }

    public FilmManager GetFilm(int id)
    {
        return null;
    }

    public List<FilmModel> GetFilms()
    {
        return null;
    }
}

}