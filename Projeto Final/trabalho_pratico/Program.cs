using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;

namespace trabalho_pratico
{
    //genero de animes/mangas
    enum Genero
    {
        SHONEN,
        SEINEN,
        SHOUJO,
        HORROR,
        PSYCHOLOGICAL,
        ROMANCE,
        ACTION,
        SCIFI,
        MECHA,
        FANTASY,
        COMEDY
    }
    //tipo/formato do anime
    enum Tipo_Anime
    {
        SERIES,
        MOVIE,
        OVA,
        ONA
    }
    //tipo/formato da manga
    enum Tipo_Manga
    {
        ONESHOT,
        SERIES,
        ANTHOLOGY
    }
    //classe abstrata pessoa
    //eu separei pessoa e utilizador porque assim é possivel usar a classe Pessoa como pai de uma possivel classe Admin
    abstract class Pessoa
    {
        private string _nome;
        public string nome { get { return _nome; } set { _nome = value; } }

        DateTime _data_nascimento;
        public DateTime data_nascimento { get { return _data_nascimento; } set { _data_nascimento = value; } }

    }

    //classe Utiliador herda os membros da classe Pessoa
    //contem a lista de animes que quer ver (WanToWatch), os que viu (Watched) e a lista de Favoritos
    //também a lista de mangas que quer ver (WanToRead), os que leu (Completed)
    class Utilizador : Pessoa
    {
        private string _password;
        public string password { get { return _password; } set { _password = value; } }

        public List<Anime> Animes_Favoritos;
        public List<Manga> Mangas_Favoritos;
        public List<Anime> WantToWatch;
        public List<Anime> Watched;
        public List<Manga> WantToRead;
        public List<Manga> Completed;

        //construtores de utilizador com e sem a data de nascimento
        public Utilizador(string nome, string password)
        {
            this.nome = nome;
            this.password = password;
        }

        public Utilizador(string nome, string password, DateTime data_nasc)
        {
            this.nome = nome;
            this.password = password;
            this.data_nascimento = data_nasc;
        }

        //Lista de Animes
        //colocar na lista de animes que quer ver (WantToWatch)
        public string ColocarToWatch(string titulo, Tipo_Anime tipo)
        {
            if (Anime_BD.ListaAnimes == null)
            {
                return "Lista Vazia";
            }
            else
            {
                foreach (var anime in Anime_BD.ListaAnimes)
                {
                    if (anime.titulo == titulo && anime.tipo == tipo)
                    {
                        WantToWatch.Add(anime);
                        return "Adicionado aos favoritos";
                    }
                }
                return "Não encontrado";
            }
        }

        //colocar na lista de animes que ja viu (Watched)
        public string ColocarWatched(string titulo, Tipo_Anime tipo)
        {
            if (Anime_BD.ListaAnimes == null)
            {
                return "Lista Vazia";
            }
            else
            {
                foreach (var anime in Anime_BD.ListaAnimes)
                {
                    if (anime.titulo == titulo && anime.tipo == tipo)
                    {
                        Watched.Add(anime);
                        return "Adicionado aos favoritos";
                    }
                }
                return "Não encontrado";
            }
        }

        //ver os titulos na lista de animes que quer ver
        public List<string> VerToWatch()
        {
            List<string> resultado = new List<string>();
            if (WantToWatch == null)
            {
                return resultado;
            }
            else
            {
                foreach (var anime in WantToWatch)
                {
                    resultado.Add(anime.titulo + anime.tipo);
                }
                return resultado;
            }
        }
        //ver os titulos na lista de animes que ja viu
        public List<string> VerWatched()
        {
            List<string> resultado = new List<string>();
            if (Watched == null)
            {
                return resultado;
            }
            else
            {
                foreach (var anime in Watched)
                {
                    resultado.Add(anime.titulo + anime.tipo);
                }
                return resultado;
            }
        }
        //passa da lista towatch para watched
        public bool ToWatchSendWatched(string nome, Tipo_Anime tipo) 
        {
            if (WantToWatch == null)
            {
                return false;
            }
            else
            {
                foreach (var anime in WantToWatch)
                {
                    if (anime.titulo == nome && anime.tipo == tipo)
                    {
                        Watched.Add(anime);
                        WantToWatch.Remove(anime);
                        return true;
                    }
                }
                return false;
            }
        }

        //colocar anime na lista Watched em Favoritos
        public string ColocarFavoritoAnime(string titulo, Tipo_Anime tipo)
        {
            if (Watched == null)
            {
                return "Lista Vazia";
            } else
            {
                foreach (var anime in Watched)
                {
                    if (anime.titulo == titulo && anime.tipo == tipo)
                    {
                        Animes_Favoritos.Add(anime);
                        return "Adicionado aos favoritos";
                    }
                }
                return "Não encontrado";
            }
        }

        //ver titulos nos animes favoritos
        public List<string> VerFavoritoAnime()
        {
            List<string> resultado = new List<string>();

            if (Animes_Favoritos == null)
            {
                return resultado;
            }
            else
            {
                foreach (var anime in Animes_Favoritos)
                {
                    resultado.Add(anime.titulo + anime.tipo);
                }
                return resultado;
            }
        }

        //classificar animes que ja viu
        public bool ClassificarAnime(string titulo, Tipo_Anime tipo, int value)
        {
            try
            {
                int i = 0;
                foreach (var anime in Watched)
                {
                    if (anime.titulo == titulo && anime.tipo == tipo)
                    {
                        Watched[i].classificacao = value; //adiciona a classificação a esse elemento da lista
                        return true;
                    }
                    i++;
                }
                return false;
            }
            catch (Exception e) { return false; }
        }
        //colocar mangas que quer ler
        public string ColocarToRead(string titulo, Tipo_Manga tipo)
        {
            if (Manga_BD.ListaMangas == null)
            {
                return "Lista Vazia";
            }
            else
            {
                foreach (var manga in Manga_BD.ListaMangas)
                {
                    if (manga.titulo == titulo && manga.tipo == tipo)
                    {
                        WantToRead.Add(manga);
                        return "Adicionado aos favoritos";
                    }
                }
                return "Não encontrado";
            }
        }
        //colocar mangas que ja leu
        public string ColocarCompleted(string titulo, Tipo_Manga tipo)
        {
            if (Manga_BD.ListaMangas == null)
            {
                return "Lista Vazia";
            }
            else
            {
                foreach (var manga in Manga_BD.ListaMangas)
                {
                    if (manga.titulo == titulo && manga.tipo == tipo)
                    {
                        Completed.Add(manga);
                        return "Adicionado aos favoritos";
                    }
                }
                return "Não encontrado";
            }
        }
        //ver os titulos na lista que quer ler
        public List<string> VerToRead()
        {
            List<string> resultado = new List<string>();
            if (WantToRead == null)
            {
                return resultado;
            }
            else
            {
                foreach (var manga in WantToRead)
                {
                    resultado.Add(manga.titulo + manga.tipo);
                }
                return resultado;
            }
        }
        //ver titulos na lista que ja leu
        public List<string> VerCompleted()
        {
            List<string> resultado = new List<string>();
            if (Completed == null)
            {
                return resultado;
            }
            else
            {
                foreach (var manga in Completed)
                {
                    resultado.Add(manga.titulo + manga.tipo);
                }
                return resultado;
            }
        }
        //passa da lista toread para completed
        public bool ToReadSendCompleted(string nome, Tipo_Manga tipo) 
        {
            if (WantToRead == null)
            {
                return false;
            }
            else
            {
                foreach (var manga in WantToRead)
                {
                    if (manga.titulo == nome && manga.tipo == tipo)
                    {
                        Completed.Add(manga);
                        WantToRead.Remove(manga);
                        return true;
                    }
                }
                return false;
            }
        }

        
        //colocar mangas nos favoritos
        public string ColocarFavoritoManga(string titulo, Tipo_Manga tipo)
        {
            if (Completed == null)
            {
                return "Lista Vazia";
            }
            else
            {
                foreach (var manga in Completed)
                {
                    if (manga.titulo == titulo && manga.tipo == tipo)
                    {
                        Mangas_Favoritos.Add(manga);
                        return "Adicionado aos favoritos";
                    }
                }
                return "Não encontrado";
            }
        }
        //ver titulos nos favoritos
        public List<string> VerFavoritoManga()
        {
            List<string> resultado = new List<string>();

            if (Mangas_Favoritos == null)
            {
                return resultado;
            }
            else
            {
                foreach (var manga in Mangas_Favoritos)
                {
                    resultado.Add(manga.titulo + manga.tipo);
                }
                return resultado;
            }
        }
        //classificar manga que ja leu
        public bool ClassificarManga(string titulo, Tipo_Manga tipo, int value)
        {
            try
            {
                int i = 0;
                foreach (var manga in Completed)
                {
                    if (manga.titulo == titulo && manga.tipo == tipo)
                    {
                        Completed[i].classificacao = value; //adiciona a classificação a esse elemento da lista
                        return true;
                    }
                    i++;
                }
                return false;
            } catch (Exception e) { return false; }
        }
    }

    //classe manga usada pra listas que guardam instancias da manga
    class Manga
    {
        private string _titulo;
        public string titulo { get { return _titulo; } set { _titulo = value; } }

        private string _autor;
        public string autor { get { return _autor; } set { _autor = value; } }

        private DateTime _start;
        public DateTime start { get { return _start; } set { _start = value; } }

        private int _chapter;
        public int chapter { get { return _chapter; } set { _chapter = value; } }

        private Genero _genero;
        public Genero genero { get { return _genero; } set { _genero = value; } }

        private Tipo_Manga _tipo;
        public Tipo_Manga tipo { get { return _tipo; } set { _tipo = value; } }

        private int _classificacao;
        public int classificacao { get { return _classificacao; } set { if (value >0 && value < 11)_classificacao = value; } }

        public Manga()
        { }
        public Manga(string titulo, string autor, DateTime start, int chapter, Genero genero, Tipo_Manga tipo)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.start = start;
            this.chapter = chapter;
            this.tipo = tipo;
            this.classificacao = 0;
        }

    }

    //classe com lista que vai receber as instancias da classe manga
    class Manga_BD 
    {
        static public List<Manga> ListaMangas;

        public Manga_BD()
        {
            ListaMangas = new List<Manga>();
        }
        //adicionar manga à lista
        public bool AdicionarManga(string titulo, string autor, DateTime start, int chapter, Genero genero, Tipo_Manga tipo)
        {
            //verifica se a nova manga já está lista
            //inclui o tipo porque às vezes a série em si e o oneshot que serve como preview têm o mesmo nome
            if (ListaMangas.Find(a => a.titulo == titulo) != null && ListaMangas.Find(a => a.tipo == tipo) != null)
                return false;

            ListaMangas.Add(new Manga(titulo, autor, start, chapter, genero, tipo));
            ListaMangas.Sort();//após ser adicionado manga, reorganizar a lista
            return true;
        }
        //mostrar todos as propriedades de cada instancia
        public List<Manga> MostrarListaDetalhada()
        {
            Resultado(ListaMangas.Count);
            return ListaMangas;
        }
        //mostrar titulos das mangas
        public List<string> MostrarTitulos()
        {
            List<string> resultado = new List<string>();

            foreach (var manga in ListaMangas)
            {
                resultado.Add(manga.titulo);
            }
            Resultado(resultado.Count);
            return resultado;
        }
        //pesquisar por titulo da manga
        public List<Manga> PesquisarTitulo(string nome)
        {
            List<Manga> resultado = new List<Manga>();
            foreach (var manga in ListaMangas)
            {
                if (manga.titulo == nome)
                {
                    resultado.Add(manga);
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }
        //pesquisar por autor
        public List<string> PesquisarAutor(string autor)
        {
            List<string> resultado = new List<string>();
            foreach (var manga in ListaMangas)
            {
                if (manga.autor == autor)
                {
                    resultado.Add(manga.titulo + manga.tipo + manga.genero);// devolve lista com o titulo, tipo e genero da instancia
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }
        //mostra todos os titulos do genero indicado
        public List<string> PesquisarGenero(Genero genero)
        {
            List<string> resultado = new List<string>();
            foreach (var manga in ListaMangas)
            {
                if (manga.genero == genero)
                {
                    resultado.Add(manga.titulo + manga.tipo);
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }
        //mostra todos as instancias com o mesmo titulo, no caso do oneshot e a serialização tenham o mesmo nome
        public List<Tipo_Manga> Desembiguação(string nome)
        {
            List<Tipo_Manga> resultado = new List<Tipo_Manga>();
            foreach (var manga in ListaMangas)
            {
                if (manga.titulo == nome)
                {
                    resultado.Add(manga.tipo);
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }
        //atribuir valor a propriedade classificação da instancia
        public bool Classificar(string titulo, Tipo_Manga tipo, int value)
        {
            try
            {
                int i = 0;
                foreach (var manga in ListaMangas)
                {
                    if (manga.titulo == titulo && manga.tipo == tipo)
                    {
                        ListaMangas[i].classificacao = value; //adiciona a classificação a esse elemento da lista
                        return true;
                    }
                    i++;
                }
                return false;
            }
            catch (Exception e) { return false; }
        }
        //métudo chamado para retornar mensagem 
        //em relação ao numero de resultados obtidos no métudo que o invoca
        private string Resultado(int count)
        {
            if (count == 0)
            {
                return "O função que executou não encontrou nada";
            }
            else if (count == 1)
            {
                return "Só existe uma entrada";
            }
            else
            {
                return "";
            }
        }
    }

    class Anime
    {
        private string _titulo;
        public string titulo { get { return _titulo; } set { _titulo = value; } }

        private string _estudio;
        public string estudio { get { return _estudio; } set { _estudio = value; } }

        private DateTime _start;
        public DateTime start { get { return _start; } set { _start = value; } }

        private int _episode;
        public int episode { get { return _episode; } set { _episode = value; } }

        private Genero _genero;
        public Genero genero { get { return _genero; } set { _genero = value; } }

        private Tipo_Anime _tipo;
        public Tipo_Anime tipo { get { return _tipo; } set { _tipo = value; } }

        private Manga _source;
        public Manga source { get { return _source; } set { _source = value; } }

        private int _classificacao;
        public int classificacao { get { return _classificacao; } set { if (value > 0 && value < 11) _classificacao = value; } }

        public Anime()
        { }
        public Anime(string titulo, string estudio, DateTime start, int episode, Genero genero, Tipo_Anime tipo)
        {
            this.titulo = titulo;
            this.estudio = estudio;
            this.start = start;
            this.episode = episode;
            this.tipo = tipo;
            this.source = null;
            this.classificacao = 0;
        }
    }

     class Anime_BD 
     {
        static public List<Anime> ListaAnimes;

        public Anime_BD()
        {
                ListaAnimes = new List<Anime>();
        }
        public bool AdicionarAnime(string titulo, string autor, DateTime start, int chapter, Genero genero, Tipo_Anime tipo)
        {
            //verifica se a nova manga já está lista
            //inclui o tipo porque às vezes a série em si e o oneshot que serve como preview têm o mesmo nome
            if (ListaAnimes.Find(a => a.titulo == titulo) != null && ListaAnimes.Find(a => a.tipo == tipo) != null)
                return false;

            ListaAnimes.Add(new Anime(titulo, autor, start, chapter, genero, tipo));
            ListaAnimes.Sort();//após ser adicionado anime, reorganizar a lista
            return true;
        }
        //atribui instancia manga à propriedade source, caso o anime seja baseado numa manga
        public bool AdicionarSource(string titulo)
        {
            int i = 0;
            foreach (var manga in Manga_BD.ListaMangas)
            {
                if (manga.titulo==titulo && manga.tipo == Tipo_Manga.SERIES)
                {
                    ListaAnimes[i].source = manga;
                    return true;
                }
                i++;
            }
            return false;
        }

        public List<Anime> MostrarListaDetalhada()
        {
            Resultado(ListaAnimes.Count);
            return ListaAnimes;
        }

        public List<string> MostrarTitulos()
        {
            List<string> resultado = new List<string>();
            foreach (var anime in ListaAnimes)
            {
                resultado.Add(anime.titulo);
            }
            Resultado(resultado.Count);
            return resultado;
        }

        public List<Anime> PesquisarTitulo(string nome)
        {
            List<Anime> resultado = new List<Anime>();
            foreach (var anime in ListaAnimes)
            {
                if (anime.titulo == nome)
                {
                    resultado.Add(anime);
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }

        public List<string> PesquisarEstudio(string estudio)
        {
            List<string> resultado = new List<string>();
            foreach (var anime in ListaAnimes)
            {
                if (anime.estudio == estudio)
                {
                    resultado.Add(anime.titulo + anime.tipo + anime.genero);
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }

        public List<string> PesquisarGenero(Genero genero)
        {
            List<string> resultado = new List<string>();
            foreach (var anime in ListaAnimes)
            {
                if (anime.genero == genero)
                {
                    resultado.Add(anime.titulo + anime.tipo);
                }
            }
            Resultado(resultado.Count);
            return resultado;
        }

        public bool Classificar(string titulo, Tipo_Anime tipo, int value)
        {
            try
            {
                int i = 0;
                foreach (var anime in ListaAnimes)
                {
                    if (anime.titulo == titulo && anime.tipo == tipo)
                    {
                        ListaAnimes[i].classificacao = value; //adiciona a classificação a esse elemento da lista
                        return true;
                    }
                    i++;
                }
                return false;
            }
            catch (Exception e) { return false; }
        }

        private string Resultado(int count)
        {
            if (count == 0)
            {
                return "O função que executou não encontrou nada";
            }
            else if (count == 1)
            {
                return "Só existe uma entrada";
            }
            else
            {
                return "";
            }
        }
    }

     class Program
     {
        static void Main(string[] args)
        {
            Manga_BD Mangas = new Manga_BD();
            Anime_BD Animes = new Anime_BD();
            Utilizador user = new Utilizador("bruno","123");
            Mangas.AdicionarManga("Attack on Titan", "Isayama", DateTime.Today, 100, Genero.ACTION, Tipo_Manga.SERIES);
            Animes.AdicionarAnime("Attack on Titan Final Season", "WitStudio", DateTime.Today, 16, Genero.ACTION, Tipo_Anime.SERIES);
            Animes.AdicionarSource("Attack on Titan");
            Mangas.MostrarListaDetalhada();
            Mangas.MostrarTitulos();
            Mangas.PesquisarTitulo("Attack on Titan");
            Mangas.PesquisarAutor("Isayama");
            Mangas.PesquisarGenero(Genero.ACTION);
            Mangas.PesquisarGenero(Genero.COMEDY);
            Mangas.Classificar("Attack on Titan",Tipo_Manga.SERIES, 6);
            Mangas.Classificar("Attack on Titan", Tipo_Manga.SERIES, 12);
            Mangas.Classificar("Attack on Titan", Tipo_Manga.SERIES, 0);
            Mangas.Desembiguação("Attack on Titan");

            Animes.MostrarTitulos();
            Animes.MostrarListaDetalhada();
            Animes.PesquisarEstudio("WitStudio");

            user.ColocarFavoritoAnime("Attack on Titan Final Season", Tipo_Anime.SERIES);
            user.VerFavoritoAnime();
        }
     }
 }