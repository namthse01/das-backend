CREATE DATABASE DAS

USE DAS;

CREATE TABLE Users( ID INT IDENTITY(1,1) PRIMARY KEY, UserName NVARCHAR(100), PhoneNum NVARCHAR(100), Gender NVARCHAR(100), Information NVARCHAR(100), Descriptions NVARCHAR(100))

CREATE TABLE Account( ID INT IDENTITY(1,1) PRIMARY KEY, userId INT, Username NVARCHAR(100) UNIQUE, Password VARCHAR(100), roleId INT, accountStatus VARCHAR(100), workingStatus VARCHAR(100))

CREATE TABLE DAServices( ID INT IDENTITY(1,1) PRIMARY KEY, ServiceName NVARCHAR(100), Intro NVARCHAR(1000), Contents NVARCHAR(1000), Outro NVARCHAR(1000), lowPrice INT, advancedPrice INT, topPrice INT, imgUrl VARCHAR(100), accountId INT, ServiceIsActive INT, Rating INT)

CREATE TABLE Booking( ID INT IDENTITY(1,1) PRIMARY KEY, CustomerName NVARCHAR(100), phoneNo NVARCHAR(100), Gender NVARCHAR(100),bookingStatus VARCHAR(100), accountId INT, slotId INT, totalPrice INT) 

CREATE TABLE BookingDetail (ID INT IDENTITY(1,1) PRIMARY KEY, bookingId INT, serviceId INT, serviceType VARCHAR(100))

CREATE TABLE Slot (ID INT IDENTITY(1,1) PRIMARY KEY, slotNo INT,slotStatus VARCHAR(100), date Datetime,dayInWeek VARCHAR(100) ,accountId INT, doctorName NVARCHAR(100))

CREATE TABLE Roles (ID INT PRIMARY KEY, roleName VARCHAR(100))

ALTER TABLE Slot
ADD FOREIGN KEY (accountId) REFERENCES Account(ID);

ALTER TABLE DAServices
ADD FOREIGN KEY (accountId) REFERENCES Account(ID);

ALTER TABLE Booking
ADD FOREIGN KEY (accountId) REFERENCES Account(ID);

ALTER TABLE Booking
ADD FOREIGN KEY (slotId) REFERENCES Slot(ID);

ALTER TABLE BookingDetail
ADD FOREIGN KEY (serviceId) REFERENCES DAServices(ID);

ALTER TABLE BookingDetail
ADD FOREIGN KEY (bookingId) REFERENCES Booking(ID);

ALTER TABLE Account
ADD FOREIGN KEY (userId) REFERENCES Users(ID);

ALTER TABLE Account
ADD FOREIGN KEY (roleId) REFERENCES Roles(ID);

INSERT INTO Roles(ID, roleName)
VALUES (1,'admin');

INSERT INTO Roles(ID, roleName)
VALUES (2,'manager');

INSERT INTO Roles(ID, roleName)
VALUES (3,'customer');

INSERT INTO Roles(ID, roleName)
VALUES (4,'doctor');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Hoàng Nam','039456128', 'Male');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Hoàng Minh','039753487', 'Male');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Nguyên Tuân','039756421', 'Male');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Hoàng Hiếu','039785461', 'Male');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Thanh Tùng','036789412', 'Male');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Minh Tâm','039785642', 'Female');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Đô Khải','039785412', 'Female');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Hoa Hạnh','039754631', 'Female');

INSERT INTO Users(UserName, PhoneNum, Gender)
VALUES (N'Hoàng Linh','039468721', 'Female');


INSERT INTO Account(roleId, userId, Username, Password, workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=2),(SELECT ID FROM Users WHERE ID=1), 'namthse01','123','working','isActive')

INSERT INTO Account(roleId, userId, Username, Password,workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=1),(SELECT ID FROM Users WHERE ID=2), 'minh','123','working','isActive')

INSERT INTO Account(roleId, userId, Username, Password, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=3),(SELECT ID FROM Users WHERE ID=3), 'tuan','123','isActive')

INSERT INTO Account(roleId, userId, Username, Password, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=3),(SELECT ID FROM Users WHERE ID=4), 'hieu','123','isActive')

INSERT INTO Account(roleId, userId, Username, Password,workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=4),(SELECT ID FROM Users WHERE ID=5), 'tung','123','working','isActive')

INSERT INTO Account(roleId, userId, Username, Password,workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=4),(SELECT ID FROM Users WHERE ID=6), 'tam','123','working','isActive')

INSERT INTO Account(roleId, userId, Username, Password,workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=4),(SELECT ID FROM Users WHERE ID=7), 'khai','123','working','isActive')

INSERT INTO Account(roleId, userId, Username, Password,workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=4),(SELECT ID FROM Users WHERE ID=8), 'hanh','123','working','isActive')

INSERT INTO Account(roleId, userId, Username, Password,workingStatus, accountStatus)
VALUES((SELECT ID FROM Roles WHERE ID=4),(SELECT ID FROM Users WHERE ID=9), 'linh','123','working','isActive')

INSERT INTO DAServices (
    ServiceName,
    Intro,
    Contents,
    Outro,
    lowPrice,
    advancedPrice,
    topPrice,
    accountId,
    ServiceIsActive,
    Rating
) VALUES (
    'Teeth Whitening Kits',
    'Transform Your Smile at Your Pace with Teeth Whitening Kits from King''s Teeth',
    'Imagine achieving a brilliantly white smile on your schedule. At King''s Teeth Dental Clinic, our Teeth Whitening Kits empower you to whiten your teeth in the comfort of your home. Our customized kits include professional-grade whitening gel and custom-fitted trays. The process is easy: you wear the trays for a specified time each day, and over a few weeks, you''ll notice a significant difference in the brightness of your smile.',
    'Experience the convenience of teeth whitening on your own terms with Teeth Whitening Kits from King''s Teeth Dental Clinic. We''re dedicated to helping you achieve the dazzling smile you deserve.',
    70, 120, 180, 1, 1, 4
);

INSERT INTO DAServices (
    ServiceName,
    Intro,
    Contents,
    Outro,
    lowPrice,
    advancedPrice,
    topPrice,
    accountId,
    ServiceIsActive,
    Rating
) VALUES (
    'Dental Sealants',
    'Shielding Your Smile with Dental Sealants at King''s Teeth',
    'At King''s Teeth Dental Clinic, we understand the importance of preventive care. Our Dental Sealants service is designed to provide an extra layer of protection for your molars, the most vulnerable to cavities. Dental sealants involve the application of a thin, protective resin to the chewing surfaces of your back teeth, creating a barrier against bacteria and food particles that can lead to decay. This painless procedure is particularly beneficial for children and those who are prone to cavities.',
    'Invest in your family''s oral health with Dental Sealants from King''s Teeth Dental Clinic. Our skilled dental professionals make this preventive step simple, providing you with peace of mind knowing you''re taking proactive measures to safeguard your smiles.',
    60, 100, 140, 1, 1, 4
);


INSERT INTO DAServices(ServiceName, Intro,Contents,Outro,lowPrice,advancedPrice,topPrice,accountId,ServiceIsActive,Rating)
VALUES('Hygeine & Periodontal Health',
'Welcome to King''s Teeth Dental Clinic, where we prioritize your Hygiene & Periodontal Health through our dedicated dental service. A healthy smile starts with the foundation of clean gums and excellent oral hygiene practices. Our experienced team is committed to helping you achieve and maintain optimal gum health for a lifetime of strong teeth and a radiant smile.',
'Our Hygiene & Periodontal Health service is designed to prevent and treat gum disease, also known as periodontal disease. Our skilled dental hygienists specialize in gentle yet thorough cleanings to remove plaque, tartar, and bacteria that can lead to gum issues. Regular appointments for hygiene maintenance play a crucial role in preventing gum disease, ensuring that your gums remain pink, firm, and free from inflammation. We also provide personalized guidance on maintaining proper oral hygiene practices at home to further promote your gum health.',
'Invest in the well-being of your gums and smile with our Hygiene & Periodontal Health service at King''s Teeth Dental Clinic. Your comfort and oral health are our priorities, and we''re here to offer you the expertise and care needed to keep your gums in optimal condition. Schedule your appointment today to experience the benefits of a clean, healthy mouth that contributes to overall wellness and the confidence of a beautiful smile.',
169,197,282,1,1,3)

INSERT INTO DAServices(ServiceName, Intro,Contents,Outro,lowPrice,advancedPrice,topPrice,accountId,ServiceIsActive,Rating)
VALUES('Post-Op Instruction',
'Congratulations on completing your dental procedure at King''s Teeth Dental Clinic. Your comfort and successful recovery are of utmost importance to us. To ensure that you experience a smooth healing process and achieve the best results possible, we provide comprehensive Post-Operative Instructions tailored to your specific procedure.',
'Our Post-Op Instruction service offers clear and concise guidance on how to care for your oral health after a dental procedure. Whether you''ve undergone oral surgery, restorative treatments, or any other dental intervention, following these instructions is crucial for minimizing discomfort, preventing complications, and promoting a swift recovery. From managing pain and swelling to maintaining proper oral hygiene and dietary choices, our instructions are designed to support your healing journey.',
'At King''s Teeth Dental Clinic, our commitment to your well-being extends beyond the procedure room. We want to ensure that your recovery is as comfortable and successful as possible. By adhering to our Post-Op Instructions, you''re taking proactive steps toward achieving optimal results and maintaining the health and beauty of your smile. If you have any questions or concerns, don''t hesitate to reach out to our team – we''re here to guide you every step of the way.',
169,197,282,1,1,3)

INSERT INTO DAServices (
    ServiceName,
    Intro,
    Contents,
    Outro,
    lowPrice,
    advancedPrice,
    topPrice,
    accountId,
    ServiceIsActive,
    Rating
) VALUES (
    'Teeth Cleaning and Check-ups',
    'Maintain Your Smile''s Radiance with Teeth Cleaning and Check-ups at King''s Teeth',
    'Regular care is the foundation of a healthy smile, and at King''s Teeth Dental Clinic, our Teeth Cleaning and Check-ups service is tailored to your needs. Our thorough dental cleanings remove plaque and tartar buildup, and our comprehensive examinations detect any potential issues early on. This proactive approach helps you maintain optimal oral health and avoid more extensive treatments in the future.',
    'Prioritize your smile''s well-being with Teeth Cleaning and Check-ups from King''s Teeth Dental Clinic. Our skilled team is dedicated to helping you achieve and sustain a vibrant and healthy smile.',
    80, 120, 160, 1, 1, 4
);

INSERT INTO DAServices (ServiceName, Intro, Contents, Outro, lowPrice, advancedPrice, topPrice, accountId, ServiceIsActive, Rating)
VALUES ('Dental X-Rays',
'Gain insights into your oral health with our Dental X-Rays service. Our clinic offers state-of-the-art radiography to visualize your teeth, gums, and underlying structures, aiding in accurate diagnoses and treatment planning.',
'Dental X-Rays are essential for detecting hidden dental issues, such as cavities, infections, and bone abnormalities. We ensure that our X-ray procedures are safe and efficient, minimizing your exposure to radiation.',
'Invest in your oral health with our Dental X-Rays service. By providing a clear picture of your dental condition, we empower you to make informed decisions about your dental care.',
56,50,100,1,1,5);

INSERT INTO DAServices (ServiceName, Intro, Contents, Outro, lowPrice, advancedPrice, topPrice, accountId, ServiceIsActive, Rating)
VALUES ('Cavity Fillings',
'Address tooth decay and restore your oral health with our Cavity Fillings service. Our experienced dentists use advanced techniques to remove decay and fill cavities, helping you maintain a strong and functional smile.',
'Our Cavity Fillings service involves removing the decayed portion of the tooth and filling the space with high-quality filling materials. We prioritize your comfort and ensure that the procedure is as efficient and pain-free as possible.',
'Regain the comfort and functionality of your teeth with Cavity Fillings at our clinic. Our dedicated dental professionals are here to provide you with personalized care that enhances your oral well-being.',
56,90,150,1,1,4);

INSERT INTO DAServices (ServiceName, Intro, Contents, Outro, lowPrice, advancedPrice, topPrice, accountId, ServiceIsActive, Rating)
VALUES ('Teeth Grinding (Bruxism) Treatment',
'Protect your teeth from the effects of teeth grinding with our Bruxism Treatment service. Our clinic offers solutions to prevent further damage and alleviate the discomfort associated with bruxism.',
'Bruxism Treatment may include custom-made nightguards to wear while sleeping, preventing teeth grinding and reducing the risk of dental issues. Our experienced team helps you find relief from bruxism-related symptoms.',
'Restore your oral health and enjoy restful nights with Bruxism Treatment from our clinic. We''re committed to providing effective solutions that enhance your well-being.',
56,150,300,1,1,5);

INSERT INTO DAServices (
    ServiceName,
    Intro,
    Contents,
    Outro,
    lowPrice,
    advancedPrice,
    topPrice,
    accountId,
    ServiceIsActive,
    Rating
) VALUES (
    'Teeth Cleaning and Check-ups',
    'Maintain Your Smile''s Radiance with Teeth Cleaning and Check-ups at King''s Teeth',
    'Regular care is the foundation of a healthy smile, and at King''s Teeth Dental Clinic, our Teeth Cleaning and Check-ups service is tailored to your needs. Our thorough dental cleanings remove plaque and tartar buildup, and our comprehensive examinations detect any potential issues early on. This proactive approach helps you maintain optimal oral health and avoid more extensive treatments in the future.',
    'Prioritize your smile''s well-being with Teeth Cleaning and Check-ups from King''s Teeth Dental Clinic. Our skilled team is dedicated to helping you achieve and sustain a vibrant and healthy smile.',
    80, 120, 160, 1, 1, 4
);


