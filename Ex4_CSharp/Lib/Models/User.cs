using System;
using System.Collections.Generic;

namespace Ex4_CSharp.Lib.Models
{
    //propietats de la classe encapsulades
    public class User
    {
        private static int ID_COUNTER = 0;
        public int Id { get; set; }
        public Guid ProID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<Video> VideoList { get; set; }
        
        //constructor per defecte
        // public User()
        // {
        //     ID_COUNTER++;
        //     Id = ID_COUNTER;
        //     ProID = Guid.NewGuid();
        //     RegisterDate = DateTime.Now;
        // }

        //sobrecarga de constructor
        public User(string Username, string Name, string Surname, string Password)
        {
            ID_COUNTER++;
            Id = ID_COUNTER;
            ProID = Guid.NewGuid();
            this.Username = Username;
            this.Name = Name;
            this.Surname = Surname;
            this.Password = Password;
            RegisterDate = DateTime.Now;
            this.VideoList = new List<Video>();
        }

        //mètode per veure info
        public string getUserInfo()
        {
            return $"Aquesta és la teva informació:\n- Id: {Id}\n- ProID: {ProID}\n- Usuari: {Username}\n- Nom: {Name}\n- Cognom: {Surname}\n- Contrasenya: {Password}\n- Data de registre: {RegisterDate}";
        }

        //mètode per veure la llista de vídeos
        public void ShowVideoList()
        {
            foreach (var video in VideoList)
            {
                Console.WriteLine(video.ToString());
            }
        }
    }
}