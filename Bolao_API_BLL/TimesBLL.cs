using Bolao_API_MODEL;
using System;

namespace Bolao_API_BLL;
public class TimesBLL
{
    private Bolao_API_DAL.TimesDAL _DAL;

    public TimesBLL()
    {
        _DAL = new Bolao_API_DAL.TimesDAL();
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
