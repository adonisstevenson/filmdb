using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using filmdb.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace filmdb{
    public interface IFilmManager
    {
        FilmManager AddFilm(FilmModel filmModel);
        FilmManager ChangeTitle(int id, string newTitle);
        bool FilmExists(int id);
        FilmModel GetFilm(int id);
        List<FilmModel> GetFilms();
        FilmManager RemoveFilm(int id);
        FilmManager UpdateFilm(FilmModel filmModel);
    }

    public class FilmManager : IFilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Add(filmModel);
                // TODO: Wyjasnic dlaczego ID dodawanego filmu to >1000
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    // filmModel.ID = null;
                    context.Add(filmModel);
                    context.SaveChanges();
                }
            }

            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {

                var film = context.Films.SingleOrDefault(x => x.ID == id);
                context.Remove(film);
                context.SaveChanges();

                // stare i glupie
                // FilmModel film = context.Films.Find(id);
                // context.Films.Remove(film);
                // context.SaveChanges();
            }


            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Films.Update(filmModel);
                context.SaveChanges();
            }

            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new FilmContext())
            {
                FilmModel film = context.Films.SingleOrDefault(x => x.ID == id);

                if (newTitle == null)
                {
                    newTitle = "Brak tytułu";
                }

                film.Title = newTitle;
                this.UpdateFilm(film);
            }

            return this;
        }

        public FilmModel GetFilm(int id)
        {

            using (var context = new FilmContext())
            {
                FilmModel film = context.Films.SingleOrDefault(x => x.ID == id);

                return film;
            }
        }

        public bool FilmExists(int id)
        {
            using (var context = new FilmContext())
            {
                if (context.Films.Any(o => o.ID == id))
                {
                    return true;
                }
                return false;
            }
        }

        public List<FilmModel> GetFilms()
        {
            using (var context = new FilmContext())
            {

                var films = context.Films.ToList();
                return films;
            }
        }

    }

}