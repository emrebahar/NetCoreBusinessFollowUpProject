using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.Interfaces
{
    public interface IDosyaService
    {
        /// <summary>
        /// Geriye Üretmiş ve upload etmiş olduğu pdf dosyasının virtual path'ini döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string AktarPdf<T>(List<T> list) where T:class, new();
        /// <summary>
        /// GEriye Excel verisini byte dizisi olarak döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] AktarExcel<T>(List<T> list) where T : class, new();
    }
}
