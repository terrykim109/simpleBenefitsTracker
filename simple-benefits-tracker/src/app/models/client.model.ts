export interface Client {
  Client_ID: number;
  First_Name: string;
  Last_Name: string;
  Current_Program: string;
  Current_Status: string;
  Program_StartDate: string;
  Program_ExpiryDate: string;
  Program_LastRenewal: string;
  Email_Address: string;
  Next_AppointmentDate?: string | null;
}
