using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Мод.Разр.Пецевич_ПР22_102_практ5.Models;

namespace Мод.Разр.Пецевич_ПР22_102_практ5
{
    internal class Helper
    {
        private static ХлебопекарняEntities1 _context;
        public static ХлебопекарняEntities1 GetContext()
        {
            if (_context == null)
            {
                _context = new ХлебопекарняEntities1();
            }
            return _context;
        }
        public void CreateUser(Authorization user)
        {
            _context.Authorization.Add(user); // Добавление записи нового пользователя
            _context.SaveChanges(); // Сохранение изменений в БД
        }
        public void UpdateUser(Authorization user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges(); // Сохранение изменений в БД
        }
        public void RemoveUser(int idUser)
        {
            var user = _context.Authorization.Find(idUser);
            if (user != null)
            {
                _context.Authorization.Remove(user);
                _context.SaveChanges(); // Сохранение изменений в БД
            }
        }
        public List<Authorization> FiltrUsers()
        {
            return _context.Authorization.Where(x => x.Login.StartsWith("M") || x.Login.StartsWith("A")).ToList();
        }
        public List<Authorization> SortUsers()
        {
            return _context.Authorization.OrderBy(x => x.Login).ToList();
        }
    }
}
