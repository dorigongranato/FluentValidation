namespace FluentValidation.Entity.ErrorModel
{
    public class ErrosViewModel
	{
        public ErrosViewModel(List<string> erros)
        {
            Erros = erros;
        }

        public List<string> Erros { get; set; }
    }
}

