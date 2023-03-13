﻿using Dulcepastel.Models.utility.interfaces;
using Dulcepastel.Models.utility.structView;
using Microsoft.EntityFrameworkCore;

namespace Dulcepastel.Models.tipoDocumento;

public class TipoDocumento : IGeneric<TipoDocumento, GenericView>
{
    public void Equals(TipoDocumento? set, TipoDocumento? get)
    {
        set!._descripcion = get?._descripcion ?? set._descripcion;
        set._idUserUpd = get?._idUserUpd ?? set._idUserUpd;
    }

    public List<GenericView> Find(params dynamic[] param)
    {
        List<GenericView> genericList = new List<GenericView>();

        return genericList;
    }

    public string Insert(TipoDocumento? objecto)
    {
        throw new NotImplementedException();
    }

    string IGeneric<TipoDocumento, GenericView>.Update(string id, TipoDocumento? objeto)
    {
        throw new NotImplementedException();
    }

    public string Delete(string id, string idUser)
    {
        throw new NotImplementedException();
    }
    
    private string? _tipoDocId;
    private string? _descripcion;
    private string? _idUserCre;
    private DateTime? _create;
    private string? _idUserUpd;
    private DateTime? _update;

    public string? TipoDocId
    {
        get => _tipoDocId;
        set => _tipoDocId = value;
    }

    public string? IdUserCre
    {
        get => _idUserCre;
        set => _idUserCre = value;
    }

    public DateTime? Create
    {
        get => _create;
        set => _create = value;
    }

    public string? IdUserUpd
    {
        get => _idUserUpd;
        set => _idUserUpd = value;
    }

    public DateTime? Update
    {
        get => _update;
        set => _update = value;
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }
}