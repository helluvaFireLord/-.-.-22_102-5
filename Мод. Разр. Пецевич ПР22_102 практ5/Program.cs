using HashPasswords;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Мод.Разр.Пецевич_ПР22_102_практ5.Models;

namespace Мод.Разр.Пецевич_ПР22_102_практ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добавление новой учетной записи пользователя");

            // Ввод логина и пароля
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            // Хеширование пароля
            string hashedPassword = Hash.HashPassword(password);

            // Создаем объект пользователя
            Authorization newUser = new Authorization
            {
                Login = login,
                Password = hashedPassword
            };
            try
            {
                using (ХлебопекарняEntities1 db = Helper.GetContext())
                {
                    db.Authorization.Add(newUser);
                    db.SaveChanges();
                }

                Console.WriteLine("\nПользователь успешно добавлен!");
                Console.WriteLine($"Логин: {login}");
                Console.WriteLine($"Хеш пароля: {hashedPassword}");
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("Ошибка валидации данных:");

                foreach (var validationError in ex.EntityValidationErrors)
                {
                    foreach (var error in validationError.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: {error.PropertyName}, Ошибка: {error.ErrorMessage}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}

