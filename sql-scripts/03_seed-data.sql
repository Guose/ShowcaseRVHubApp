BEGIN TRY
    BEGIN TRAN

    BEGIN
        INSERT INTO ShowcaseRVHubDB.dbo.ShowcaseUsers (Id, Email, FirstName, LastName, Phone, Username, Password, CreatedOn, ModifiedOn, IsRemembered)
        VALUES 
        ('cf3e94b7-4052-4585-86e8-b4ea68ba1bdf', 'justin@showcasemi.com', 'Justin', 'Elder', NULL, 'justy', 'pass', '2023-08-14', NULL, 1),
        ('add00d60-8544-4fcc-9494-b4993b05472b', 'cuggle1008@gmail.com', 'Kathleen', 'Lordan', '(425) 802-2164', 'cuggle', 'myPass', '2023-10-08', NULL, 0);
    END;
    BEGIN
        INSERT INTO ShowcaseRVHubDB.dbo.VehicleRVs (Id, Make, Model, Year, Chassis, Class, Sleeps, Length, Height, Image, Description, CreatedOn, ModifiedOn, Odometer, GeneratorHours, MasterBedType, IsBooked, HasGenerator, HasSlideOut, UserId)
        VALUES 
        (-1, 'Winnebago', 'Minnie Winnie 22R', 2015, 'Ford', 3, 6, 23, 13.2, 'C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/minniewinnie.jpg', 'Great for family vacations with all the extras included to make your trip enjoyable, feasible, and easy to use. Features include: RV has master bedroom with queen bed & wardrobe cabinet, queen bed over the cab, dinette converts to bed, full bathroom & shower, stove/oven combo, microwave, refrigerator/freezer, AC unit, electric awning, & plenty of storage. Clean bedding, pots, pans, plates, bowls, coffee maker, cups, & kitchen utensils included in rental. Other add-ons are available for rental: inflatable rafting tube, kayaks, paddle boards, sledding tubes, etc. 24/7 support with certified techs available to address the unexpected. We do offer delivery and pickup services and flexible with pickup & return times. Secure onsite parking of your vehicle is available on request. Towing of any trailer, boat, or vehicle is prohibited. Reservation dates confirmed once payment is made. If you have questions, please let us know.', '2032-09-12', NULL, 79362.0, 72, 3, 1, 1, 0, 'cf3e94b7-4052-4585-86e8-b4ea68ba1bdf'),
        (-2, 'Forest River', 'Sunseeker', 2019, 'Ford', 3, 6, 27, 12.6, 'C:/Users/Guose/source/repos/GitHubRepos/ShowcaseRVHubApp/ShowcaseRVHub.MAUI/Resources/Images/sunseeker.jpg', 'Excellent for family vacations with all the extras included to make your trip enjoyable, feasible, and easy to use. Features include: RV has solar panels, thermal windows, and Artic Pack for winter travels, one slide out to increase living space, private master bedroom with memory foam queen bed & wardrobe area/cabinet, full queen bed above drivers seat, dinette converts to bed, full bathroom and shower, stove/oven combo, microwave, refrigerator/freezer, 2 AC units, motorized awning for easy access, and plenty of undercarriage storage area. Clean bedding, pots, pans, plates, bowls, coffee maker, cups, and kitchen utensils are included in rental. Other add-ons are available for rental: inflatable rafting tube, kayaks, paddle boards, sledding tubes, etc. 24/7 support with certified techs available to address the unexpected. We do offer delivery and pickup services and flexible with pickup & return times. Secure onsite parking of your vehicle is available on request. Towing of any trailer, boat, or vehicle is prohibited. Reservation dates confirmed once payment is made. If you have questions, please let us know.', '2023-08-14', NULL, 68912.0, 48, 2, 0, 1, 1, 'cf3e94b7-4052-4585-86e8-b4ea68ba1bdf');
    END;

    COMMIT;
END TRY
BEGIN CATCH
    -- Roll back the transaction if an error occurs
    ROLLBACK;

	-- Get the error message
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();

    -- Get the error number
    DECLARE @ErrorNumber INT = ERROR_NUMBER();

	-- Log the error and insert details into the error log table
	INSERT INTO master.dbo.ErrorLog(ErrorNumber, ErrorMessage, ErrorTime)
    VALUES (@ErrorNumber, @ErrorMessage, GETDATE());

END CATCH;