namespace SonicaWebAdmin.SonicaAdmin.Interfaces
{
    /// <summary>
    /// Объект подлежит ручному освобождению, если больше не используется.
    /// Например: некоторые операции объекта могут не дать обработать его сборщиком мусора. 
    /// </summary>
    public interface IReleasable
    {
        void Release();
    }
}
