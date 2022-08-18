CREATE TABLE Users
(
    UserID VARCHAR(7),
    UserName VARCHAR(50),
    FirstName VARCHAR(50),
    Surnames VARCHAR(50),
    DoB DATE,
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    UserPassword VARCHAR(255),
    AccountType VARCHAR(255),
    PRIMARY KEY (UserID)
);

CREATE TABLE Rooms
(
    RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
    RoomNumber VARCHAR(10),
    Campus VARCHAR(50),
    RoomCapacity INT
);

CREATE TABLE ServiceProvider
(
    ProviderID INTEGER PRIMARY KEY AUTOINCREMENT,
    ProviderName VARCHAR(255)
);

CREATE TABLE The_Services
(
    ServiceID INTEGER PRIMARY KEY AUTOINCREMENT,
    ServiceName VARCHAR(100),
    ServiceDescription VARCHAR(2000),
    ProviderID NUMBER,
    PlaceID NUMBER,
    ServiceDate DATE,
    ServiceDuration VARCHAR(10),
    ServiceCapacity INT,
    FOREIGN KEY(ProviderID) REFERENCES ServiceProvider(ProviderID),
    FOREIGN KEY(PlaceID) REFERENCES Rooms(RoomID)
);

CREATE TABLE Events
(
    EventID INTEGER PRIMARY KEY AUTOINCREMENT,
    EventName VARCHAR(100),
    EventDescription VARCHAR(2000),
    HostID VARCHAR(7),
    PlaceID NUMBER,
    EventDate DATE,
    EventDuration VARCHAR(10),
    EventCapacity INT,
    FOREIGN KEY(HostID) REFERENCES Users(UserID),
    FOREIGN KEY(PlaceID) REFERENCES Rooms(RoomID)
);

CREATE TABLE BookingServices
(
    SBookingID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserID VARCHAR(7),
    ServiceID NUMBER,
    Status VARCHAR(50),
    FOREIGN KEY(UserID) REFERENCES Users(UserID),
    FOREIGN KEY(ServiceID) REFERENCES The_Services(ServiceID)
);

CREATE TABLE BookingEvents
(
    EBookingID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserID VARCHAR(7),
    EventID NUMBER,
    Status VARCHAR(50),
    FOREIGN KEY(UserID) REFERENCES Users(UserID),
    FOREIGN KEY(EventID) REFERENCES Events(EventID)
);

CREATE TABLE Notifications
(
    NotificationID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserID VARCHAR(7),
    NotificationDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    NotificationTittle VARCHAR(50),
    NotificationText VARCHAR(2000),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Log
(
    LogID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserID VARCHAR(7),
    LogDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    LogDatqa VARCHAR(2000),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);