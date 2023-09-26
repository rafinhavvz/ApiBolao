using apiBolao.Model;
using System;

namespace apiBolao.Api_BLL;
public class BoloesBLL
{
    private Api_DAL.BoloesDAL _DAL;

    public BoloesBLL()
    {
        _DAL = new Api_DAL.BoloesDAL();
    }

    public List<Boloes> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public Boloes GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public int PostItem(Boloes oItem)
    {
        var data =  _DAL.PostItem(oItem);

        return data;
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public Boloes UpdateItem(Boloes oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
