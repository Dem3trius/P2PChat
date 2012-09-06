namespace Chat_v1
{
    /// <summary>
    /// Класс що містить інформацію про роботу програми та різні її налаштування.
    /// </summary>
    public static class Default
    {
        // Стандартний порт для вхідних сервісних повідомлень
        public const int def_service_list_port = 33232;

        // Стандартний порт для вхідних текстових повідомлень
        public const int def_text_list_port = 33233;

        // Стандартний порт для передачі файлів
        public const int def_file_list_port = 33234;

        // Стандартний розмір буферу для пересилання даних (512 Kb)
        public const int def_buffer_size = 1024 * 512; 
    }

    /// <summary>
    /// Помилки, що можуть виникнути під час роботи програми
    /// </summary>
    public enum ErrorCode
    {
        // Неможу створити сокет на цій адресі
        BadIP,

        // Інший користувач відключений або недоступний
        CannotConnect
    }

    /// <summary>
    /// Коди усіх можливих повідомлень
    /// </summary>
    public enum MessageType
    {
        Null, 

        ConnectionAsk,       // Запит на підключення
        ConnectionAccepted,  // Запит на підключення прийняте
        ConnectionCanceled,  // Запит на підключення відхилений
        ConnectionUserAdded, // До чату додано нового користувача
        ConnectionClosed,    // З'єднання закрито

        TextData,            // Повідомлення містить текстові дані

        Echo,                // Запит на встановлення, чи є користувач в мережі
        LoggedOut,           // Користувач вийшов з мережі
        LoggedIn,            // Користувач ввійшов в мережу 
        IsAlive,             // Відповідь на "Echo"

        FilesTableAvailable, // Користувач може надсилати файли
        FilesAsk,            // Запит на отримання файлу            
        FileDataFirst,       // Відповідь на FileAsk. Старт передачі
        FileData,            // Повідомлення містить дані файлу що передається
        FileDataLast,        // Закінчення передачі файлу
    }

    public enum OnlineState
    {
        Online,
        Offline,
        Unknown
    }
}
