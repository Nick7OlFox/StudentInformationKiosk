using System;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    class Database
    {
        private String query, location, relativePath, parentdir, trimmedPath, absolutePath;

        public Database()
        {
            relativePath = @"Database\database.db";
            parentdir = Path.GetDirectoryName(Application.StartupPath);
            trimmedPath = parentdir.Remove(parentdir.Length - 25, 25);
            absolutePath = Path.Combine(trimmedPath, relativePath);

            location = string.Format("DataSource={0}", absolutePath);
            location = location.Replace(@"\",@"\\");
            Console.WriteLine(location);
        }
        public void Log(String userID, String text)
        {
            query = "INSERT INTO Log(UserID, LogData) VALUES((SELECT UserID FROM Users WHERE UserID=\"" + userID + "\"),\"" + text + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public string getpassword(String userName)
        {
            String dbPassword = "Error";

            query = "SELECT UserPassword FROM Users WHERE UserName=" + "\"" + userName + "\"" + ";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dbPassword = dr["UserPassword"].ToString();

                            }
                        }
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return dbPassword;
        }
        public string getID(String userName)
        {
            String dbPassword = "Free";

            query = "SELECT UserPassword FROM Users WHERE UserID=" + "\"" + userName + "\"" + ";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dbPassword = dr["UserPassword"].ToString();

                            }
                        }
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return dbPassword;
        }
        public string getUserName(String userName)
        {
            String dbPassword = "Free";

            query = "SELECT UserPassword FROM Users WHERE UserName=" + "\"" + userName + "\"" + ";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dbPassword = dr["UserPassword"].ToString();

                            }
                        }
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return dbPassword;
        }
        public void register(String userID, String userName, String first, String surname, String doB, String email, String phone, String password)
        {

            query = "INSERT INTO Users VALUES(\"" + userID + "\",\"" + userName + "\",\"" + first + "\",\"" + surname + "\",\"" + doB + "\",\"" + email + "\",\"" + phone + "\",\"" + password + "\",\"User\");";


            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public User getUserInfo(String userName)
        {
            User user = new User();

            query = "SELECT * FROM Users WHERE UserName = (\"" + userName + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                user.UserID = dr["UserID"].ToString();
                                user.UserName = userName;
                                user.FirstName = dr["FirstName"].ToString();
                                user.Surname = dr["Surnames"].ToString();
                                user.DateOfBirth = dr["DoB"].ToString();
                                user.Email = dr["Email"].ToString();
                                user.PhoneNumber = dr["PhoneNumber"].ToString();
                                user.Password = dr["UserPassword"].ToString();
                                user.Priviledge = dr["AccountType"].ToString();
                            }

                            conn.Close();
                        }
                    }
                    catch(Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return user;
        }
        public List<String> getCampus()
        {
            List<String> List = new List<string>();

            query = "SELECT DISTINCT Campus FROM Rooms;";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                String campus;

                                campus = dr["Campus"].ToString();

                                List.Add(campus);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return List;
        }
        public List<String> getProviders()
        {
            List<String> List = new List<string>();

            query = "SELECT ProviderName FROM ServiceProvider;";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                String provider;

                                provider = dr["ProviderName"].ToString();

                                List.Add(provider);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return List;
        }
        public Place getRoom(String ID)
        {
            Place place = new Place();

            query = "SELECT * FROM Rooms WHERE RoomID=\"" + ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                place.ID = ID;
                                place.Number = dr["RoomNumber"].ToString();
                                place.Campus = dr["Campus"].ToString();
                                place.Capacity = Int32.Parse(dr["RoomCapacity"].ToString());
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return place;
        }
        public Provider GetProvider(String ID)
        {
            Provider provider = new Provider();

            query = "SELECT * FROM ServiceProvider WHERE ProviderID=\"" + ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                provider.ID = ID;
                                provider.Name = dr["ProviderName"].ToString();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return provider;
        }
        public Services getSpecificService(String ID)
        {
            Services service = new Services();

            query = "SELECT * FROM The_Services WHERE ServiceID=\"" + ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                service.ID = Int32.Parse(dr["ServiceID"].ToString());
                                service.Name = dr["ServiceName"].ToString();
                                service.Description = dr["ServiceDescription"].ToString();
                                service.Provider = dr["ProviderID"].ToString();
                                service.Place = dr["PlaceID"].ToString();
                                service.Date = dr["ServiceDate"].ToString();
                                service.Start = dr["StartTime"].ToString();
                                service.Duration = dr["ServiceDuration"].ToString();
                                service.Capacity = Int32.Parse(dr["ServiceCapacity"].ToString());
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return service;
        }
        public String checkSBook(String userID, String serviceID)
        {
            String alreadyBooked, ID = "";

            query = "SELECT * FROM BookingServices WHERE UserID=\"" + userID + "\" AND ServiceID=\"" + serviceID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ID = dr["SBookingID"].ToString();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            if(ID.Equals(""))
            {
                alreadyBooked = "No";
            }
            else
            {
                alreadyBooked = "Yes";
            }
            return alreadyBooked;
        }
        public void bookService(String userID, String serviceID)
        {
            query = "INSERT INTO BookingServices(UserID, ServiceID) VALUES((SELECT UserID FROM Users WHERE UserID=\"" + userID + "\"),(SELECT ServiceID FROM The_Services WHERE ServiceID=\"" + serviceID + "\"));";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            query = "UPDATE The_Services SET ServiceCapacity = (ServiceCapacity - 1)  WHERE ServiceID = \"" + serviceID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public List<Services> getServices(String Priviledge)
        {
            Services service;
            List<Services> List = new List<Services>();

            if (Priviledge.Equals("Administrator"))
            {
                query = "SELECT * FROM The_Services;";
            }

            else
            {
                query = "SELECT * FROM The_Services WHERE ServiceCapacity > 0;";
            }

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                service = new Services();

                                service.ID = Int32.Parse(dr["ServiceID"].ToString());
                                service.Name = dr["ServiceName"].ToString();
                                service.Description = dr["ServiceDescription"].ToString();
                                service.Provider = dr["ProviderID"].ToString();
                                service.Place = dr["PlaceID"].ToString();
                                service.Date = dr["ServiceDate"].ToString();
                                service.Start = dr["StartTime"].ToString();
                                service.Duration = dr["ServiceDuration"].ToString();
                                service.Capacity = Int32.Parse(dr["ServiceCapacity"].ToString());

                                List.Add(service);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return List;
        }
        public Provider GetNewProvider(String providerName)
        {
            Provider provider = new Provider();

            query = "SELECT * FROM ServiceProvider WHERE ProviderName=\"" + providerName + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                provider.ID = dr["ProviderName"].ToString();
                                provider.Name = providerName;
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return provider;
        }
        public Place getNewRoom(String campus, String roomNumber)
        {
            Place place = new Place();

            query = "SELECT * FROM Rooms WHERE RoomNumber=\"" + roomNumber + "\" AND Campus=\"" + campus + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                place.ID = dr["RoomID"].ToString(); ;
                                place.Number = roomNumber;
                                place.Campus = campus;
                                place.Capacity = Int32.Parse(dr["RoomCapacity"].ToString());
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return place;
        }
        public void updateService(Services services, String providerName, String campus, String room)
        {
            query = "UPDATE The_Services SET ServiceName = \"" + services.Name + "\", ServiceDescription = \"" + services.Description + "\", ProviderID = (SELECT ProviderID FROM ServiceProvider WHERE ProviderName=\"" + providerName + "\"), PlaceID = (SELECT RoomID FROM Rooms WHERE Campus=\"" + campus + "\" AND RoomNumber=\"" + room + "\"), ServiceDate = \"" + services.Date + "\", StartTime = \"" + services.Start + "\", ServiceDuration = \"" + services.Duration + "\", ServiceCapacity = \"" + services.Capacity + "\" WHERE ServiceID = \"" + services.ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public void addService(Services services, String providerName, String campus, String room)
        {
            query = "INSERT INTO The_Services(ServiceName, ServiceDescription, ProviderID, PlaceID, ServiceDate, StartTime, ServiceDuration, ServiceCapacity) Values(\"" + services.Name + "\",\"" + services.Description + "\",(SELECT ProviderID FROM ServiceProvider WHERE ProviderName=\"" + providerName + "\"),(SELECT RoomID FROM Rooms WHERE Campus=\"" + campus + "\" AND RoomNumber=\"" + room + "\"),\"" + services.Date + "\",\"" + services.Start + "\",\"" + services.Duration + "\",\"" + services.Capacity + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public void deleteService(String serviceID)
        {
            query = "DELETE FROM The_Services WHERE ServiceID = \"" + serviceID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            query = "DELETE FROM BookingServices WHERE ServiceID = \"" + serviceID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public List<Events> getEvent(String Priviledge, String userID)
        {
            Events events;
            List<Events> List = new List<Events>();

            if (Priviledge.Equals("Administrator"))
            {
                query = "SELECT * FROM Events;";
            }

            else if(Priviledge.Equals("Contributor"))
            {
                query = "SELECT * FROM Events WHERE EventCapacity > 0 OR HostID = \"" + userID + "\";";
            }
            else
            {
                query = "SELECT * FROM Events WHERE EventCapacity > 0;";
            }

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                events = new Events();

                                events.ID = Int32.Parse(dr["EventID"].ToString());
                                events.Name = dr["EventName"].ToString();
                                events.Description = dr["EventDescription"].ToString();
                                events.Host = dr["HostID"].ToString();
                                events.Place = dr["PlaceID"].ToString();
                                events.Date = dr["EventDate"].ToString();
                                events.Start = dr["StartTime"].ToString();
                                events.Duration = dr["EventDuration"].ToString();
                                events.Capacity = Int32.Parse(dr["EventCapacity"].ToString());

                                List.Add(events);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return List;
        }
        public Events getSpecificEvent(String ID)
        {
            Events e = new Events();

            query = "SELECT * FROM Events WHERE EventID=\"" + ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                e.ID = Int32.Parse(dr["EventID"].ToString());
                                e.Name = dr["EventName"].ToString();
                                e.Description = dr["EventDescription"].ToString();
                                e.Host = dr["HostID"].ToString();
                                e.Place = dr["PlaceID"].ToString();
                                e.Date = dr["EventDate"].ToString();
                                e.Start = dr["StartTime"].ToString();
                                e.Duration = dr["EventDuration"].ToString();
                                e.Capacity = Int32.Parse(dr["EventCapacity"].ToString());
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception err)
                    {
                        conn.Close();
                        Console.WriteLine(err);
                    }
                }
            }
            return e;
        }
        public List<String> getHosts()
        {
            List<String> List = new List<string>();

            query = "SELECT userName FROM Users WHERE AccountType = \"Contributor\" OR AccountType = \"Administrator\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                String host;

                                host = dr["userName"].ToString();

                                List.Add(host);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            return List;
        }
        public String GetHost(String ID)
        {
            String hostName = null;

            query = "SELECT UserName FROM Users WHERE UserID=\"" + ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                hostName = dr["userName"].ToString();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return hostName;
        }
        public void updateEvent(Events e, String campus, String room)
        {
            query = "UPDATE Events SET EventName = \"" + e.Name + "\", EventDescription = \"" + e.Description + "\", HostID = (SELECT UserID FROM Users WHERE UserName=\"" + e.Host + "\"), PlaceID = (SELECT RoomID FROM Rooms WHERE Campus=\"" + campus + "\" AND RoomNumber=\"" + room + "\"), EventDate = \"" + e.Date + "\", StartTime = \"" + e.Start + "\", EventDuration = \"" + e.Duration + "\", EventCapacity = \"" + e.Capacity + "\" WHERE EventID = \"" + e.ID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public void addEvent(Events e, String hostID, String campus, String room)
        {
            query = "INSERT INTO Events(EventName, EventDescription, HostID, PlaceID, EventDate, StartTime, EventDuration, EventCapacity) Values(\"" + e.Name + "\",\"" + e.Description + "\",(SELECT UserID FROM Users WHERE UserID=\"" + hostID + "\"),(SELECT RoomID FROM Rooms WHERE Campus=\"" + campus + "\" AND RoomNumber=\"" + room + "\"),\"" + e.Date + "\",\"" + e.Start + "\",\"" + e.Duration + "\",\"" + e.Capacity + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }
        }
        public void deleteEvent(String eventID)
        {
            query = "DELETE FROM Events WHERE EventID = \"" + eventID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            query = "DELETE FROM BookingEvents WHERE EventID = \"" + eventID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public String checkEBook(String userID, String eventID)
        {
            String alreadyBooked, ID = "";

            query = "SELECT * FROM BookingEvents WHERE UserID=\"" + userID + "\" AND EventID=\"" + eventID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ID = dr["EBookingID"].ToString();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            if (ID.Equals(""))
            {
                alreadyBooked = "No";
            }
            else
            {
                alreadyBooked = "Yes";
            }
            return alreadyBooked;
        }
        public void bookEvent(String userID, String eventID)
        {
            query = "INSERT INTO BookingEvents(UserID, EventID) VALUES((SELECT UserID FROM Users WHERE UserID=\"" + userID + "\"),(SELECT EventID FROM Events WHERE EventID=\"" + eventID + "\"));";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            query = "UPDATE Events SET EventCapacity = (EventCapacity - 1)  WHERE EventID = \"" + eventID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public List<BookedService> GetBookedService(String userID)
        {
            List<BookedService> List = new List<BookedService>();
            BookedService b;

            query = "SELECT * FROM BookingServices WHERE UserID = \"" + userID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                b = new BookedService();

                                b.ID = dr["SBookingID"].ToString();
                                b.User = userID;
                                b.ServID = dr["ServiceID"].ToString();

                                query = "SELECT ServiceName, ServiceDate FROM The_Services WHERE ServiceID=\"" + b.ServID + "\";";

                                using (SQLiteCommand c = new SQLiteCommand(conn))
                                {
                                    c.CommandText = query;
                                    try
                                    {
                                        c.ExecuteNonQuery();

                                        using (System.Data.SQLite.SQLiteDataReader d = c.ExecuteReader())
                                        {
                                            while (d.Read())
                                            {
                                                b.Name = d["ServiceName"].ToString();
                                                b.Date = d["ServiceDate"].ToString();
                                            }
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        Console.WriteLine(err);
                                    }
                                }

                                    List.Add(b);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return List;
        }
        public List<BookedEvent> GetBookedEvent(String userID)
        {
            List<BookedEvent> List = new List<BookedEvent>();
            BookedEvent b;

            query = "SELECT * FROM BookingEvents WHERE UserID = \"" + userID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                b = new BookedEvent();

                                b.ID = dr["EBookingID"].ToString();
                                b.User = userID;
                                b.EventID = dr["EventID"].ToString();

                                query = "SELECT EventName, EventDate FROM Events WHERE EventID=\"" + b.EventID + "\";";

                                using (SQLiteCommand c = new SQLiteCommand(conn))
                                {
                                    c.CommandText = query;
                                    try
                                    {
                                        c.ExecuteNonQuery();

                                        using (System.Data.SQLite.SQLiteDataReader d = c.ExecuteReader())
                                        {
                                            while (d.Read())
                                            {
                                                b.Name = d["EventName"].ToString();
                                                b.Date = d["EventDate"].ToString();
                                            }
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        Console.WriteLine(err);
                                    }
                                }

                                List.Add(b);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return List;
        }
        public void deleteBookS(String ID, String userID, String servID)
        {
            query = "DELETE FROM BookingServices WHERE SBookingID = \"" + ID + "\" AND UserID=\"" + userID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            query = "UPDATE The_Services SET ServiceCapacity = (ServiceCapacity + 1)  WHERE ServiceID = \"" + servID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public void deleteBookE(String ID, String userID, String eventID)
        {
            query = "DELETE FROM BookingEvents WHERE EBookingID = \"" + ID + "\" AND UserID=\"" + userID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }

            query = "UPDATE Events SET EventCapacity = (EventCapacity + 1)  WHERE EventID = \"" + eventID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public void updateAccount(User e)
        {
            query = "UPDATE Users SET FirstName = \"" + e.FirstName + "\", Surnames = \"" + e.Surname + "\", DoB = \"" + e.DateOfBirth + "\", Email = \"" + e.Email + "\", PhoneNumber = \"" + e.PhoneNumber + "\" WHERE UserID = \"" + e.UserID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }
        }
        public void updatePassword(User e)
        {
            query = "UPDATE Users SET UserPassword = \"" + e.Password + "\" WHERE UserID = \"" + e.UserID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }
        }
        public void deleteAccount(User e)
        {
            query = "UPDATE Events SET EventCapacity = (EventCapacity + 1)  WHERE EventID = (SELECT EventID FROM BookingEvents WHERE UserID= \"" + e.UserID + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }

            query = "UPDATE The_Services SET ServiceCapacity = (ServiceCapacity + 1)  WHERE ServiceID = (SELECT ServiceID FROM BookingServices WHERE UserID= \"" + e.UserID + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }

            query = "DELETE FROM BookingEvents WHERE UserID = \"" + e.UserID + "\" OR EventID = (SELECT EventID FROM Events WHERE HostID = \"" + e.UserID + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }

            query = "DELETE FROM BookingServices WHERE UserID = \"" + e.UserID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }

            query = "DELETE FROM Events WHERE HostID = \"" + e.UserID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }


            query = "DELETE FROM Users WHERE UserID = \"" + e.UserID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }
        }
        public void GetUser(User u)
        {
            query = "SELECT * FROM Users WHERE UserID = (\"" + u.UserID + "\");";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                u.UserName = dr["UserName"].ToString();
                                u.FirstName = dr["FirstName"].ToString();
                                u.Surname = dr["Surnames"].ToString();
                                u.DateOfBirth = dr["DoB"].ToString();
                                u.Email = dr["Email"].ToString();
                                u.PhoneNumber = dr["PhoneNumber"].ToString();
                                u.Password = dr["UserPassword"].ToString();
                                u.Priviledge = dr["AccountType"].ToString();
                            }

                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
        }
        public void updatePriviledge(User e)
        {
            query = "UPDATE Users SET AccountType = \"" + e.Priviledge + "\" WHERE UserID = \"" + e.UserID + "\";";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch (Exception er)
                    {
                        conn.Close();
                        Console.WriteLine(er);
                    }
                }
            }
        }
        public List<Place> getAllRooms()
        {
            List<Place> v = new List<Place>();
            Place p;

            query = "SELECT * FROM Rooms;";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                p = new Place();

                                p.ID = dr["RoomID"].ToString();
                                p.Number = dr["RoomNumber"].ToString();
                                p.Campus = dr["Campus"].ToString();
                                p.Capacity = Int32.Parse(dr["RoomCapacity"].ToString());

                                v.Add(p);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return v;
        }
        public List<String> getAllProviders()
        {
            List<String> v = new List<String>();

            query = "SELECT * FROM ServiceProvider;";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                v.Add(dr["ProviderName"].ToString());
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return v;
        }
        public List<Log> getLog()
        {
            List<Log> v = new List<Log>();
            Log l;

            query = "SELECT * FROM Log;";

            using (SQLiteConnection conn = new SQLiteConnection(location))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = query;
                    try
                    {
                        cmd.ExecuteNonQuery();

                        using (System.Data.SQLite.SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                l = new Log();

                                l.ID = dr["LogID"].ToString();
                                l.User = dr["UserID"].ToString();
                                l.Time = dr["LogDate"].ToString();
                                l.Data = dr["LogData"].ToString();

                                v.Add(l);
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine(e);
                    }
                }
            }
            return v;
        }
    }
}

