using apiBolao.Model;
using System;

namespace apiBolao.Api_BLL;
public class TimesBLL
{
    private Api_DAL.TimesDAL _DAL;

    public TimesBLL()
    {
        _DAL = new Api_DAL.TimesDAL();
    }

    public List<Times> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public Times GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public void PostItem(Times oItem)
    {
        _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public Times UpdateItem(Times oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
