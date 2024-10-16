-- Cardiology (Dept_ID = 1)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Mahmoud', N'Sami', N'Abdullah', N'Fayoum', N'Salah St', 5100, N'2022-07-10', N'M', N'Day', N'team2.png', 1);

-- Neurology (Dept_ID = 2)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Huda', N'Amin', N'Younis', N'Mansoura', N'Canal St', 4900, N'2020-09-12', N'F', N'Day', N'team3.png', 2),
(N'Saad', N'Khaled', N'Hafez', N'Cairo', N'Shabrawy St', 5200, N'2021-08-21', N'M', N'Night', N'team1.png', 2),
(N'Layla', N'Zayed', N'Salim', N'Alexandria', N'Glime St', 4700, N'2022-01-17', N'F', N'Day', N'team3.png', 2);

-- Oncology (Dept_ID = 3)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Amina', N'Hassan', N'Othman', N'Cairo', N'Downtown', 5100, N'2021-05-15', N'F', N'Night', N'team3.png', 3),
(N'Youssef', N'Adel', N'Zaki', N'Menoufia', N'Al-Geish St', 5300, N'2020-04-22', N'M', N'Day', N'team1.png', 3);

-- Pediatrics (Dept_ID = 4)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Hasan', N'Ahmed', N'Kamel', N'Cairo', N'Maadi St', 4900, N'2020-03-01', N'M', N'Day', N'team2.png', 4),
(N'Fatima', N'Youssef', N'Al-Hashmi', N'Giza', N'Talat Harb St', 4600, N'2021-11-12', N'F', N'Night', N'team3.png', 4);

-- Orthopedics (Dept_ID = 5)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Bassam', N'Saad', N'Taha', N'Cairo', N'Zamalek St', 5200, N'2020-02-18', N'M', N'Night', N'team2.png', 5),
(N'Leila', N'Nasr', N'Omar', N'Alexandria', N'Sidi Gaber Rd', 4800, N'2019-10-10', N'F', N'Day', N'team3.png', 5);

-- Radiology (Dept_ID = 6)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Rania', N'Hussein', N'Mansour', N'Mansoura', N'Bani St', 4800, N'2021-02-17', N'F', N'Day', N'team3.png', 6),
(N'Mohammed', N'Ali', N'Nassif', N'Cairo', N'Mokattam St', 5100, N'2019-06-10', N'M', N'Night', N'team2.png', 6);

-- Emergency (Dept_ID = 7)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Hassan', N'Osama', N'Shaaban', N'Cairo', N'Maadi St', 5400, N'2020-08-08', N'M', N'Night', N'team1.png', 7),
(N'Salma', N'Mahmoud', N'Ibrahim', N'Alexandria', N'Beach Rd', 4900, N'2022-09-10', N'F', N'Day', N'team3.png', 7);

-- Gastroenterology (Dept_ID = 8)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Yara', N'Mohamed', N'Ali', N'Giza', N'Faisal St', 4800, N'2022-05-11', N'F', N'Day', N'team3.png', 8),
(N'Faisal', N'Nasr', N'Kamali', N'Cairo', N'Heliopolis St', 5300, N'2022-05-11', N'M', N'Day', N'team1.png', 8);

-- Continue similarly for the remaining departments...
-- Cardiology (Dept_ID = 9)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Saad', N'Mustafa', N'Hamed', N'Cairo', N'Ramses St', 5600, N'2021-07-14', N'M', N'Day', N'team1.png', 9),
(N'Zainab', N'Faisal', N'Othman', N'Giza', N'Imbaba St', 4800, N'2020-04-08', N'F', N'Night', N'team3.png', 9);

-- Neurology (Dept_ID = 10)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Ali', N'Yasser', N'Hassan', N'Cairo', N'Abdeen St', 5400, N'2022-01-16', N'M', N'Night', N'team2.png', 10),
(N'Rania', N'Salim', N'Mahmoud', N'Alexandria', N'Fouad St', 4700, N'2020-09-21', N'F', N'Day', N'team3.png', 10);

-- Pulmonology (Dept_ID = 11)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Hussein', N'Karim', N'Sherif', N'Cairo', N'Abbassia St', 5500, N'2021-11-09', N'M', N'Day', N'team1.png', 11),
(N'Layla', N'Mahdi', N'Younes', N'Giza', N'Agouza St', 5000, N'2019-12-25', N'F', N'Night', N'team3.png', 11);

-- Dermatology (Dept_ID = 12)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Mahmoud', N'Hisham', N'Nabil', N'Alexandria', N'Stanley Rd', 5300, N'2021-06-17', N'M', N'Day', N'team2.png', 12),
(N'Salma', N'Ali', N'Mansour', N'Cairo', N'Mokattam St', 4800, N'2020-03-13', N'F', N'Night', N'team3.png', 12);

-- Psychiatry (Dept_ID = 13)
INSERT INTO [dbo].[Doctor] ([F_Name], [M_Name], [L_Name], [City], [Street], [Salary], [Hire_Date], [Gender], [Shift_Type], [ImgName], [Dept_ID]) 
VALUES 
(N'Zayd', N'Ahmed', N'Latif', N'Cairo', N'Garden City', 5700, N'2019-05-06', N'M', N'Day', N'team1.png', 13),
(N'Fatima', N'Rashid', N'Ghanem', N'Alexandria', N'Sidi Bishr Rd', 4900, N'2020-12-19', N'F', N'Night', N'team3.png', 13);
