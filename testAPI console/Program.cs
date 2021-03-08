using System;
using Npgsql;

namespace testAPI_console
{
    class Program
    {
        static void Main(string[] args)
        {   
            string connectstring = "Host=localhost;Port=7777;Database=postgres;Username=postgres;Password=13123866rT;Persist Security Info=True";
            NpgsqlConnection connect = new NpgsqlConnection(connectstring);
            link1:
            Console.WriteLine("Qo'shishni xoxlasangiz 1 ni bosing, ro'yxatni ko'rishni xoxlasangiz 2 ni");
            string v = Console.ReadLine();
            if (v == "1")
            {
                connect.Open();
                NpgsqlCommand insertCommand = new NpgsqlCommand("INSERT INTO public.users_list(user_id, user_login, user_pass, user_role_id) VALUES(@user_id, @user_login, @user_pass, @user_role_id);", connect);
                Console.Write("user_id = ");
                int user_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("user_name = ");
                string user_login = Convert.ToString(Console.ReadLine());
                Console.Write("user_pass = ");
                string user_pass = Convert.ToString(Console.ReadLine());
                char user_role_id = '2';
                insertCommand.Parameters.AddWithValue("user_id", user_id);
                insertCommand.Parameters.AddWithValue("user_login", user_login);
                insertCommand.Parameters.AddWithValue("user_pass", user_pass);
                insertCommand.Parameters.AddWithValue("user_role_id", user_role_id);
                insertCommand.ExecuteNonQuery();
                connect.Close();
                Console.WriteLine("Muofaqiyatli qo'shildi");
                Console.ReadLine();
            }


            /* int user_id;
             string user_login;
             string user_pass;
             char user_role_id = '1';*/
            else if (v == "2")
            {
                connect.Open();
                NpgsqlCommand selectCommand = new NpgsqlCommand("SELECT user_id, user_login, user_pass, user_role_id FROM public.users_list;", connect);
                NpgsqlDataReader users = selectCommand.ExecuteReader();
                while (users.Read())
                    Console.WriteLine("{0} {1} {2} {3}", users[0], users[1], users[2], users[3]);
                connect.Close();

            }

            else
            {
                Console.WriteLine("Notogri kod kiritildi");
                goto link1;
            }
            

            






        }
    }
}
