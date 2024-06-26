# Hair Salon

## Мобильное приложение для управления парикмахерской.

1. PersonalInfo:
     - FirstName - имя пользователя.
     - LastName - фамилия пользователя.
     - Email - адрес электронной почты пользователя.
     - PhoneNumber - номер телефона пользователя.
     - UpdateInfo() - метод для обновления персональной информации пользователя.

2. User:
     - PersonalInfo - персональная информация пользователя.
     - Login - логин пользователя.
     - Password - пароль пользователя.
     - ChangePassword() - метод для изменения пароля пользователя.
     - UpdatePersonalInfo() - метод для обновления персональной информации пользователя.

3. Admin (наследуется от User):
     - CheckLogin() - метод для проверки учетных данных администратора.
     - AddNewEmployee() - метод для добавления нового сотрудника.
     - AddNewClient() - метод для добавления нового клиента.
     - CreateAppointment() - метод для создания записи на услугу.
     - AddService() - метод для добавление новой услуги.
     - AddServiceType() - метод для добавления нового вида услуг.

4. Employee (наследуется от User):
     - Salary - зарплата сотрудника.
     - Services - список услуг, предоставляемых сотрудником.
     - Specialties - список специализаций(видов услуг) сотрудника.
     - AddServiceType() - метод для добавления нового вида услуг к специализациям сотрудника.
     - RemoveServiceType() - метод для удаления вида услуг из специализаций сотрудника.
     - AddService() - метод для добавления новой услуги сотруднику.
     - RemoveService() - метод для удаления услуги у сотрудника.

5. Service:
     - Name - название услуги.
     - Price - цена услуги.
     - ServiceType - вид(тип) услуги.

6. Client (наследуется от User):
      - Appointments - список записей клиента на услуги.
      - MakeAppointment() - метод для создания записи клиента на услугу.
      - CancelAppointment() - метод для отмены записи клиента на услугу.
      - UpdateContactInfo() - метод для обновления контактной информации клиента.
     - ViewAppointments() - метод для просмотра записей клиента на услуги.
     - LeaveReview() - метод для оставления отзыва.

7. Appointment:
     - EmployeeForAppointment - сотрудник, на которого назначена услуга.
     - ClientForAppointment - клиент, который записан на услугу.
     - Date - дата и время услуги.
     - ServiceForAppointment - услуга, на которую записан клиент.

8. Salon:
     - Name - название салона.
     - schedule - расписание записей на услуги для салона.
     - notificationSystem - система уведомлений о записях.
     - paymentSystem  - система оплаты записей.
     - Employees - список сотрудников салона.
     - Clients - список клиентов салона.
     - Admins - список администраторов салона.
     - Reviews - список отзывов о салоне.
     - Services - список услуг, предоставляемых салоном.
     - Discounts - список скидок на услуги
     - ServiceTypes - список видов услуг, предоставляемых салоном.
     - AddEmployee() - метод для добавления сотрудника в салон.
     - AddClient() - метод для добавления клиента в салон.
     - Register() - метод для регистрации нового клиента.
     - Login() - метод для входа в систему.
     - AddReview() - метод для добавления отзыва.
     - AddPromotion() - метод для добавления скидки.
     - ViewShedule() - метод для просмотра расписания салона.

9. Schedule:
   - Appointments - список записей на услуги.
   - AddAppointment() - метод для добавления записи на услугу в расписание.
   - CancelAppointment() - метод для отмены записи.

10. NotificationSystem:
      - ClientName - имя клиента.
      - PhoneNumber - номер телефона клиента.
      - AppointmentTime - дата и время записи.
      - ServiceForClient - услуга для клиента.
      - SendNotification() - метод для отправки уведомления клиенту о записи.
      - CancelAppointmentNotification() - метод для отправки уведомления клиенту об отмене записи.
      - RescheduleAppointment() - метод для отправки уведомления клиенту о переносе записи.


11. Discount:
      - Percentage - процент скидки.
      - StartDate - дата начала действия скидки.
      - EndDate - дата окончания действия скидки.
      - ApplyDiscount() - метод для применения скидку к услуге.

12. Review:
      - Text - текст отзыва.
      - Date - дата отзыва.
      - Rating - рейтинг отзыва.

13. PaymentSystem:
      - ProcessPayment() - метод для обработки платежа.
      - RefundPayment() - метод для возврата платежа.
      - GetPaymentHistory() - метод для получения истории платежей.
  
14. Payment:
      - Id - идентификатор платежа.
      - Amount - сумма платежа.
      - RefundAmount  - сумма возврата платежа.
      - Date - дата платежа.
      - Status - статус платежа.
