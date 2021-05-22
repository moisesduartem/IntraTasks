namespace IntraTasks.DataAccess.ValueObjects
{
    public static class ResponseFactory
    {
        public static Response<T> Successfully<T>(T data, string message = "")
        {
            return new Response <T> { Successfully = true, Message = message, Data = data };
        }

        public static Response<T> Created<T>(T data, string message = "Adicionado com sucesso")
        {
            return new Response<T> { Successfully = true, Message = message, Data = data };
        }

        public static Response<T> Updated<T>(T data, string message = "Atualizado com sucesso")
        {
            return new Response<T> { Successfully = true, Message = message, Data = data };
        }

        public static Response<T> Deleted<T>(T data, string message = "Removido com sucesso")
        {
            return new Response<T> { Successfully = true, Message = message, Data = data };
        }

        public static Response<T> NotFound<T>(string message = "Não encontrado")
        {
            return new Response<T> { Successfully = false, Message = message, Data = { } };
        }
    }
}
