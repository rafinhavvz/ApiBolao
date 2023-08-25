using Bolao_API_MODEL;
using System;

namespace Bolao_API_BLL;
public class TiposBLL
{
    private Bolao_API_DAL.TiposDAL _DAL;

    public TiposBLL()
    {
        _DAL = new Bolao_API_DAL.TiposDAL();
    }

    public List<Tipos> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public Tipos GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public void PostItem(Tipos oItem)
    {
        _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public Tipos UpdateItem(Tipos oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
