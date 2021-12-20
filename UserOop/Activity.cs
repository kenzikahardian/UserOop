using System;
using System.Collections.Generic;
using System.Text;

namespace UserOop
{
    class Activity
    {
        public List<User> user = new List<User>();
        public void ShowUser()
        {
            
            foreach (var element in user)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine($"Nama:{element.FirstName} {element.LastName}");
                Console.WriteLine($"Username:{ element.UserName }");
                Console.WriteLine($"Password:{element.HashedPassword}");
                Console.WriteLine("=========================================");
            }
        }

        public void Login()
        {
            Activity a = new Activity();
            Console.Write("Masukkan Username: ");
            var username = Console.ReadLine();
            Console.Write("Masukkan Password: ");
            var password = Console.ReadLine();
            var userN = user.Exists(x => x.UserName == username);
            var pass = user.Exists(x => BCrypt.Net.BCrypt.Verify(password, x.HashedPassword));

                if ( userN==true && pass==true)
                {
                
                Console.WriteLine("Login Berhasil");
                }
                else
                {
                
                Console.WriteLine("Login Gagal");
                }
        }
        public void SearchUser(string nama)
        {
                var validate= user.Exists(user => user.FirstName.Contains(nama)|| user.LastName.Contains(nama));
                if (validate == true && user.Count>0)
                {
                    Console.WriteLine("data ditemukan");
                    var foundUser = user.FindAll(x => x.FirstName.Contains(nama)|| x.LastName.Contains(nama));
                    foreach (User u in foundUser)
                    {
                    Console.WriteLine("=========================================");
                    Console.WriteLine($"Nama:{u.FirstName} {u.LastName}");
                    Console.WriteLine($"Username:{u.UserName }");
                    Console.WriteLine($"Password:{u.HashedPassword}");
                    Console.WriteLine("=========================================");
                    Console.ReadKey();
                }
                }
                else
                {
                    Console.WriteLine("data tidak ditemukan");
                    Console.ReadKey();
                }
        }
        public void CreateUser(User user)
        {
                this.user.Add(user);
                Console.WriteLine("==============================");
                Console.WriteLine("Sukses Menambahkan");
                Console.WriteLine("==============================");
        }
            
        public void EditUser(string username)
        {
            var validate = user.Exists(user => user.UserName==username);
            if (validate == true && user.Count > 0)
            {
                Console.WriteLine("data ditemukan");
                var foundUser = user.FindAll(x => x.UserName==username);
                foreach (User u in foundUser)
                {
                    Console.WriteLine("=========================================");
                    Console.Write("Edit Nama Depan ");
                    u.FirstName = Console.ReadLine();
                    Console.Write("Edit Nama Belakang ");
                    u.LastName = Console.ReadLine();
                    Console.Write("Edit Nama Password ");
                    u.Password = Console.ReadLine();
                    u.HashedPassword = BCrypt.Net.BCrypt.HashPassword(u.Password);
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Edit profil sukses!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("data tidak ditemukan");
                Console.ReadKey();
            }
        }
        public void DeleteUser()
        {
            try
            {
                Console.Write("Silahkan Masukkan data yang ingin di hapus :");
                //int hapus = Convert.ToInt32(Console.ReadLine());
                var dlt = Console.ReadLine();
                var validasi = user.Exists(x => x.FirstName == dlt);
                var validate = user.FindAll(user => user.FirstName == dlt);
                if (validasi == true)
                {
                    foreach (User item in validate)
                    {
                        Console.WriteLine("data berhasil dihapus");
                        user.Remove(item);
                    }
                }
                else
                {
                    Console.WriteLine("data tidak berhasil dihapus");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
