using Bolao_API_MODEL;
using System;

namespace Bolao_API_BLL;
public class ApostasBLL
{
    private Bolao_API_DAL.ApostasDAL _DAL;

    public ApostasBLL()
    {
        _DAL = new Bolao_API_DAL.ApostasDAL();
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

}
