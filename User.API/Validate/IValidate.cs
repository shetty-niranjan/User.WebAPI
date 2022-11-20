namespace User.API.Validate
{
    public interface IValidate<Tin, Tout> where Tin : new() where Tout : class
    {
        Tout Validate(Tin param);
    }
}
