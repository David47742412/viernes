﻿using Dulcepastel.Models.cliente;
using Dulcepastel.Models.ocupacion;

namespace Dulcepastel.Models.utility.interfaces;

public interface IGeneric<T>
{
    void Equals(T? set, T? get);

    List<T?> Find(params dynamic[] param);

    string Insert(T? objecto);

    string Update(string id, T? objeto);

    string Delete(string id, string idUser);

}