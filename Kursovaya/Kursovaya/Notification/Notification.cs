using System;
using System.Windows.Media;
using Tulpep.NotificationWindow;

namespace Kursovaya.Notification
{   
    static class Notification
    {
        static PopupNotifier notifier = new PopupNotifier();

        static Notification()
        {
            notifier.HeaderHeight = 1;
            notifier.HeaderColor = System.Drawing.Color.White;
            notifier.BodyColor = System.Drawing.Color.FromArgb(11, 63, 136);
            notifier.ContentPadding = new System.Windows.Forms.Padding(90, 15, 0, 15);
            notifier.ContentText = "Отправлено на обработку!!!";
            notifier.ContentColor = System.Drawing.Color.White;
            notifier.ContentHoverColor = System.Drawing.Color.White;
            notifier.ContentFont = new System.Drawing.Font("Calibri", 14);
            notifier.BorderColor = System.Drawing.Color.FromArgb(11, 63, 136);
            notifier.TitleText = "FlatHelper";
            notifier.TitleFont = new System.Drawing.Font("Calibri", 18);
            notifier.AnimationDuration = 100;
        }        
            
        /// <summary>
        /// Вызывает уведомление
        /// </summary>
        public static void NotificationPopup()
        {
            notifier.Popup();
        }
    }
}
