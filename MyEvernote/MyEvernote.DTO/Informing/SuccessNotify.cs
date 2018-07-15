namespace MyEvernote.DTO.Informing
{
    public class SuccessNotify:NotifyBase<string>
    {
        public SuccessNotify()
        {
            Title = "İşlem Başarılı.";
        }
    }
}
