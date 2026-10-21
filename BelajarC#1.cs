
using System;
using System.Collections.Generic;
namespace KerangkaGame
{
    class Karakter
    {

        public int total, power;

        //Encapsulation
        public string nama{ get; private set; }
        public int kesehatan{ get; private set; }
        public int senjata{ get; private set; }
        public int healing{ get; private set; }
        

 
        public Karakter(string nama, int kesehatan, int senjata, int healing = 0)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.healing = healing;
        }

        public void Serang(Karakter target) //Membuat medhod menyerang, contoh interaksi antar objek
        {
            Console.WriteLine("===== Mulai Serangan =====");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int JumlahSerangan) //Objek menerima serangan, contoh interaksi antar objek
        {
            kesehatan -= JumlahSerangan;
            Console.WriteLine($"{nama} menerima serangan sebesar {JumlahSerangan}. Kesehatan sekarang: {kesehatan}");
        }

        public void PakaiHealing() 
        {
            Console.WriteLine("===== Mulai Penyembuhan =====");
            this.ProsesHealing(this.healing);
        }

        public void ProsesHealing(int JumlahHealing) //Objek menerima serangan, contoh interaksi antar objek
        {
            kesehatan += JumlahHealing;
            Console.WriteLine($"{nama} menerima penyembuhan sebesar {JumlahHealing}. Kesehatan sekarang: {kesehatan}");
        }


        public void getData()
        {
            Console.WriteLine($"Karakter: {nama} | Kesehatan: {kesehatan}");
        }
    
     
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Anby", 100, 10, 20); 
            Karakter Musuh = new Karakter("Etherial", 100, 30);

            //Interaksi antar objek
            player1.Serang(Musuh); 
            Musuh.Serang(player1);
            
            player1.PakaiHealing(); 

            Console.WriteLine("\n===== STATUS AKHIR =====");
            player1.getData(); //Menampilkan data player1

        }
    }
} 
