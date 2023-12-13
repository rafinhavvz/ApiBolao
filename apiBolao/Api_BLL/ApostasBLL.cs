using apiBolao.Model;
using System;

namespace apiBolao.Api_BLL;
public class ApostasBLL
{
    private Api_DAL.ApostasDAL _DAL;

    public ApostasBLL()
    {
        _DAL = new Api_DAL.ApostasDAL();
    }

    public List<Apostas> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public Apostas GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public List<Apostas> GetItemIdBolao(int oItemId)
    {
        var data = _DAL.GetItemIdBolao(oItemId);

        return data;
    }


    public int PostItem(Apostas oItem)
    {
        return _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public Apostas UpdateItem(Apostas oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

    public void UpdateItemArray(IEnumerable<Apostas> oItemArray)
    {
         _DAL.UpdateItemArray(oItemArray); ;
    }

}
