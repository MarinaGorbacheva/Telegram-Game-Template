using System;
using UnityEngine.Scripting;

namespace Agava.TelegramGameTemplate
{
    [Serializable, Preserve]
    public class User
    {
        public long id;
        public bool is_bot;
        public string first_name;
        public string last_name;
        public string username;
        public string language_code;
        public bool? is_premium;
        public bool? added_to_attachment_menu;
        public bool? can_join_groups;
        public bool? can_read_all_group_messages;
        public bool? supports_inline_queries;
        public bool? can_connect_to_business;
        public bool? has_main_web_app;
    }
}
