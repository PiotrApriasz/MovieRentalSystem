/*
Baza danych na podstawie projektu Wypożyczalnia filmowa z Access
autorów Piotr Apriasz i Adrian Bielak.
------------------------------------------------------------------
Autor poniższego skryptu i projektu:
Piotr Apriasz
------------------------------------------------------------------
Idea projektu:
Zaimplementowanie bazy danych do obsługi stacjonarnej wypożyczalni
filmowej
*/
-- -----------------------------------------------------------------
-- Utworzenie bazy danych------------------------------------------
-- -----------------------------------------------------------------

DROP DATABASE
IF EXISTS wypozyczalnia;

CREATE DATABASE wypozyczalnia;

USE wypozyczalnia;

-- -------------------------------------------------------------------
-- Tworzenie tabel---------------------------------------------------
-- -------------------------------------------------------------------

CREATE TABLE users (
  client_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  first_name VARCHAR(128) NOT NULL,
  last_name VARCHAR(128) NOT NULL,
  email VARCHAR(128),
  birth_date DATE,
  address_id INT UNSIGNED,
  credit_card_number VARCHAR(16),
  cvv_code VARCHAR(3),
  if_active BOOLEAN
);

CREATE TABLE workers (
    worker_id varchar(4), first_name varchar(64), last_name varchar(64)
);

CREATE TABLE addresses (
  address_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  city VARCHAR(128) NOT NULL,
  building_number VARCHAR(10) NOT NULL,
  flat_number VARCHAR(10),
  street VARCHAR(128),
  postal_code VARCHAR(16)
);

CREATE TABLE movies (
  movie_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  movie_title VARCHAR(128) NOT NULL,
  movie_genre_id TINYINT NOT NULL,
  duration TIME NOT NULL,
  director_id TINYINT NOT NULL,
  for_adults BOOLEAN,
  price DECIMAL(4,2) NOT NULL,
  year_of_production DATE
);

CREATE TABLE movie_genres (
  movie_genre_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  genre_name VARCHAR(128) NOT NULL
);

CREATE TABLE rentals (
    movie_id TINYINT NOT NULL,
    movie_rented_date DATE NOT NULL,
    client_id TINYINT NOT NULL,
    return_date DATE
);

CREATE TABLE directors (
    director_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(128) NOT NULL,
    last_name VARCHAR(128) NOT NULL
);

-- -------------------------------------------------------------------
-- Dodawanie danych--------------------------------------------------
-- -------------------------------------------------------------------

-- Adresy------------------------------------------------------------

INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Krakow', 57, 34, 'Marcholta', '31-416'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Warszawa', 112, 3, 'Jana Pawla II', '01-456'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Rzeszow', 2, 48, 'os Piastow', '31-624'
       );
INSERT INTO addresses (city, building_number, postal_code)
VALUES (
        'Wojnarowa', 435, '33-322'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Poznan', 12, 122, 'Mala', '12-456'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Velen', 1, 57, 'Bagnista', '00-128'
       );
INSERT INTO addresses (city, building_number, postal_code)
VALUES (
        'Korzenna', 68, '33-331'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Gdansk', 321, 12, 'Morska', '45-567'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Zakopane', 45, 2, 'Gorska', '12-453'
       );
INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
VALUES (
        'Lodz', 45, 123, 'Cicha', '67-112'
       );


-- Reżyserzy---------------------------------------------------------

INSERT INTO directors (first_name, last_name)
VALUES (
        'Tate', 'Tylor'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'M. Night', 'Shyhamala'
      );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Jon', 'Watts'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Christ', 'Miller'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Graham', 'Moore'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Andrzej', 'Wajda'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Anna', 'E. James'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Ariel', 'Boles'
       );
INSERT INTO directors (first_name, last_name)
VALUES (
        'Wayne', 'Wang'
       );

-- Gatunki filmowe------------------------------------------------------

INSERT INTO movie_genres (genre_name)
VALUE ('Horror');
INSERT INTO movie_genres (genre_name)
VALUE ('Dramat');
INSERT INTO movie_genres (genre_name)
VALUE ('Akcja');
INSERT INTO movie_genres (genre_name)
VALUE ('Komedia');
INSERT INTO movie_genres (genre_name)
VALUE ('Komedia romantyczna');
INSERT INTO movie_genres (genre_name)
VALUE ('Sci-fi');
INSERT INTO movie_genres (genre_name)
VALUE ('Fantasy');
INSERT INTO movie_genres (genre_name)
VALUE ('Bajki');
INSERT INTO movie_genres (genre_name)
VALUE ('Anime');
INSERT INTO movie_genres (genre_name)
VALUE ('Dokumentalny');

-- Filmy-------------------------------------------------------------------

INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Spiderman - Daleko od domu', 3, '02:09:00', 3, 0, 15.00, '2019-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Slodkie chwile', 10, '00:44:00', 8, 0, 5.00, '2020-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Zabojcze zludzenia', 1, '01:54:00', 7, 1, 10.00, '2021-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Shrek 3', 8, '01:34:00', 4, 0, 15.00, '2007-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Ma', 1, '01:39:00', 1, 0, 10.00, '2019-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Pan Tadeusz', 2, '02:28:00', 6, 0, 20.00, '1999-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Pokojowka na Manhatanie', 5, '01:45:00', 9, 0, 5.00, '2002-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Gra tajemnic', 2, '01:53:00', 5, 0, 12.00, '2014-01-01'
       );
INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
VALUES (
        'Ostatni wldaca wiatru', 9, '01:44:00', 2, 0, 8.00, '2010-01-01'
       );

-- Użytkownicy------------------------------------------------------------------

INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Adam', 'Pierwszy', 'adam@gmail.com', '1999-06-10', 1, '1234567895273946', '223', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Ela', 'Zawada', 'ela@wp.pl', '1956-01-12', 2, '7389400056184620', '526', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Arkadiusz', 'Niewiadomy', 'niewiem@op.pl', '1971-12-31', 8, '6366448888261007', '122', 1
       );
       INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Robert', 'Maklowicz', 'jestemSuper@wp.pl', '1948-12-17', 6, '8823645194004736', '456', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Anna', 'Wietrzalska', 'wietrzem@gmail.com', '2007-07-05', 3, '1235640066739946', '667', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Kunegunda', 'Przypadek', 'kundziam@gmail.com', '1998-10-12', 5, '7499362222511956', '123', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Roksana', 'Lapa', 'roksana.lapa@onet.pl', '2005-06-02', 8, '9873620000371567', '445', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Tomasz', 'Walega', 'tvalega@wp.com', '1985-05-05', 1, '1674620836149326', '773', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Amadeusz', 'Krzysztof', 'aka@gmail.com', '1972-11-12', 4, '3746372937429173', '222', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Kordian', 'Wallenrod', 'krowal@gmail.com', '1997-10-10', 6, '7483926666453627', '459', 1
       );
INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
VALUES (
            'Adrian', 'Bielak', 'adrian.bielak@wp.com', '1998-08-10', 7, '0000645285712349', '123', 1
       );

-- Pracownicy

INSERT INTO workers (worker_id, first_name, last_name) VALUES ('1234', 'Piotr', 'Apriasz');

-- -------------------------------------------------------------------
-- Widoki -----------------------------------------------------------
-- -------------------------------------------------------------------

-- Widok do wyświetlenia dokładnego spisu wypożyczeń-----------------

CREATE VIEW a_detailed_list_of_rental
(FirstName, LastName, City, BuildingNumber, FlatNumber, Street, PostalCode, MovieTitle, Email, RentalDate, ReturnDate)
AS
    SELECT u.first_name, u.last_name, a.city, a.building_number, a.flat_number, a.street, a.postal_code,
           m.movie_title, u.email, r.movie_rented_date, r.return_date
    FROM users AS u
    INNER JOIN rentals r on u.client_id = r.client_id
    INNER JOIN movies m on r.movie_id = m.movie_id
    INNER JOIN addresses a on u.address_id = a.address_id;


-- Widok do wyświetlania ilości filmów jakie są przypisane do danego gatunku

CREATE VIEW genres_count_by_movies
(GenreName, MoviesCount)
AS
    SELECT g.genre_name, COUNT(*)
    FROM movie_genres AS g
    INNER JOIN movies AS m on g.movie_genre_id = m.movie_genre_id
    GROUP BY g.genre_name;

-- WIdok do wyświetlania informacji na temat filmów

CREATE VIEW informations_about_films
(Title, GenreName, Director, ProductionYear)
AS
    SELECT m.movie_title, g.genre_name, CONCAT(d.first_name, ' ', d.last_name), YEAR(m.year_of_production)
    FROM movies AS m
    INNER JOIN movie_genres AS g ON m.movie_genre_id = g.movie_genre_id
    INNER JOIN directors AS d ON m.director_id = d.director_id;

-- Widok do wyświetlania pełnych informacji o użytkownikach i ich adresach

CREATE VIEW users_and_adresses
(FirstName, LastName, City, BuildingNumber, FlatNumber, Street, PostalCode, Email, BirthDate,
    CreditCardNumber, CVVCode)
AS
    SELECT u.first_name, u.last_name, a.city, a.building_number, a.flat_number, a.street,
           a.postal_code, u.email, u.birth_date, u.credit_card_number, u.cvv_code
    FROM users AS u
    INNER JOIN addresses AS a ON u.address_id = a.address_id;

-- Widok do wyświetlania informacji o wieku i pełnoletności użytkowników

CREATE VIEW users_age
(FirstName, LastName, Age, IfMature)
AS
    SELECT u.first_name, u.last_name, TIMESTAMPDIFF(YEAR, u.birth_date, CURRENT_DATE),
           IF(TIMESTAMPDIFF(YEAR, u.birth_date, CURRENT_DATE) >= 18, 'Mature', 'Immature')
    FROM users AS u;

-- Widok do wyswietlania ile dany użytkownik ma wypożyczonych filmów i ile ma zapłacił

CREATE VIEW user_account_summary
(FirstName, LastName, NumberOfMovies, PricesSummary)
AS
    SELECT u.first_name, u.last_name, COUNT(m.movie_id), SUM(m.price)
    FROM users AS u
    INNER JOIN (movies AS m INNER JOIN rentals ON m.movie_id = rentals.movie_id)
    ON u.client_id = rentals.client_id
    GROUP BY u.client_id;

-- -------------------------------------------------------------------
-- Procedury --------------------------------------------------------
-- -------------------------------------------------------------------

-- Procedura do dodawania adresu

DELIMITER //

CREATE PROCEDURE add_address(IN City1 varchar(128), IN buildingNumber varchar(10), IN flatNumber varchar(10),
IN Street1 varchar(128), IN postalCode varchar(16))
BEGIN
    INSERT INTO addresses (city, building_number, flat_number, street, postal_code)
        VALUES (City1, buildingNumber, flatNumber, Street1, postalCode);
END //

DELIMITER ;

-- Procedura do dodawania nowych użytkowników

DELIMITER  //

CREATE PROCEDURE add_new_user(
IN firstName varchar(128), IN lastName varchar(128),  IN Email1 varchar(128),
IN birthDate DATE, IN creditCard varchar(16), IN cvvCode varchar(3),
IN City1 varchar(128), IN buildingNumber varchar(10), IN flatNumber varchar(10),
IN Street1 varchar(128), IN postalCode varchar(16),
IN addressIDCurrent smallint
)
BEGIN
    DECLARE addressId smallint;

    IF addressIDCurrent IS NULL THEN
        CALL add_address(City1, buildingNumber, flatNumber, Street1, postalCode);

        SET addressId = (SELECT MAX(address_id)
            FROM addresses WHERE city = City1 AND building_number = buildingNumber
            AND postal_code = postalCode);
    ELSE
        SET addressId = addressIDCurrent;
    end if;

    INSERT INTO users (first_name, last_name, email, birth_date, address_id, credit_card_number, cvv_code, if_active)
    VALUES  (firstName, lastName, Email1, birthDate, addressId, creditCard, cvvCode, 1);

end //

DELIMITER ;

-- Procedura do usunięcia użytkownika z bazy wypożyczalni

DELIMITER  //

CREATE PROCEDURE delete_user(IN clientID smallint)
BEGIN
    DELETE FROM users WHERE client_id = clientID;
end //

DELIMITER ;

-- Procedura do wypożyczania filmów. Zawiera zabezpiecznia przed błędami
-- kiedy chciano by wypożyczyc film ktorego nie ma lub wypożyczyć
-- film podając niepoprawne dane użytkownika. Zabezpiecza też
-- wypożyczenie filmu dla pełnoletnich przez osobę niepełnoletnią
-- i nie pozwala wypożyczyć filmu osobie zablokowanej

DELIMITER  //

CREATE PROCEDURE rent_movie(IN movieTitle varchar(128), IN Name varchar(128),
IN Surname varchar(128), IN CreditCardNumber varchar(16), IN CVVNumber varchar(3))
BEGIN
    DECLARE movieID tinyint;
    DECLARE clientID tinyint;
    DECLARE Mature varchar(8);
    DECLARE Active boolean;
    DECLARE ForAdults boolean;

    SET movieID = NULL;
    SET clientID = NULL;

    SET movieID = (SELECT movie_id FROM movies WHERE movie_title = movieTitle);
    SET clientID = (SELECT client_id FROM users WHERE first_name = Name AND
                                                      last_name = Surname AND
                                                      credit_card_number = CreditCardNumber AND
                                                      cvv_code = CVVNumber);
    SET Mature = (SELECT IfMature FROM users_age WHERE FirstName = Name AND LastName = Surname);
    SET Active = (SELECT if_active FROM users WHERE first_name = Name AND
                                                      last_name = Surname);
    SET ForAdults = (SELECT for_adults FROM movies WHERE movie_title = movieTitle);

    IF movieID IS NULL THEN SIGNAL SQLSTATE '77770' SET MESSAGE_TEXT = 'Brak filmu w bazie danych!';
    ELSEIF clientID IS NULL THEN SIGNAL SQLSTATE '77771' SET MESSAGE_TEXT = 'Nieprawidlowe dane uzytkownika!';
    ELSEIF Mature = 'Immature' AND ForAdults = 1 THEN
        SIGNAL SQLSTATE '77772' SET MESSAGE_TEXT = 'Uzytkownik jest niepelnoletni';
    ELSEIF Active = 0 THEN SIGNAL SQLSTATE '77773' SET MESSAGE_TEXT = 'Uzytkownik nie jest aktywny';
    END IF;

    INSERT INTO rentals (movie_id, client_id, movie_rented_date, return_date)
    VALUES (movieID, clientID, DATE(NOW()), DATE(NOW()) + 14);

end //

DELIMITER ;

-- Procedura do usuwania flmu z tabeli wypożyczeń kiedy jakiś użytkownik oddał film

DELIMITER  //

CREATE PROCEDURE delete_rental(IN movieTitle varchar(128), IN Name varchar(128),
IN Surname varchar(128))
BEGIN
    DECLARE movieID tinyint;
    DECLARE clientID tinyint;

    SET movieID = NULL;
    SET clientID = NULL;

    SET movieID = (SELECT movie_id FROM movies WHERE movie_title = movieTitle);
    SET clientID = (SELECT client_id FROM users WHERE first_name = Name AND
                                                      last_name = Surname);

    IF movieID IS NULL THEN SIGNAL SQLSTATE '77770' SET MESSAGE_TEXT = 'Brak filmu w bazie danych!';
    ELSEIF clientID IS NULL THEN SIGNAL SQLSTATE '77771' SET MESSAGE_TEXT = 'Nieprawidlowe dane uzytkownika!';
    END IF;

    DELETE FROM rentals WHERE client_id = clientID AND movie_id = movieID;

end //

DELIMITER ;

-- Procedura do dodawania filmów do tabeli z filmami

DELIMITER  //

CREATE PROCEDURE add_movie(IN Title varchar(128), IN GenreName varchar(64),
IN durationTime time, IN directorName varchar(128), IN directorSurname varchar(128),
IN forAdults BOOLEAN, IN Money decimal(4,2), IN productionYear DATE)
BEGIN
    DECLARE GenreId tinyint;
    DECLARE directorId tinyint;

    SET GenreId = NULL;
    SET directorId = NULL;

    SET GenreId = (SELECT movie_genre_id FROM movie_genres WHERE genre_name = GenreName);
    SET directorId = (SELECT director_id FROM directors WHERE first_name = directorName AND
                                                              last_name = directorSurname);

    IF GenreId IS NULL THEN SIGNAL SQLSTATE '77774' SET MESSAGE_TEXT = 'Brak gatunku w bazie danych!';
    ELSEIF directorId IS NULL THEN
        CALL add_director(directorName, directorSurname);

        SET directorId = (SELECT director_id FROM directors WHERE first_name = directorName
            AND last_name = directorSurname);
    END IF;

    INSERT INTO movies (movie_title, movie_genre_id, duration, director_id, for_adults, price, year_of_production)
    VALUES (Title, GenreId, durationTime, directorId, forAdults, Money, productionYear);

end //

DELIMITER ;

-- Procedura do usuwania filmów z tabeli filmów

DELIMITER  //

CREATE PROCEDURE delete_movie(IN Title varchar(128))
BEGIN
    DELETE FROM movies WHERE movie_title = Title;

end //

DELIMITER ;

-- Procedura do ręczego sprawdzania czy jakiś uzytkownik zalega z oddaniem filmu dłużej niż 14 dni
-- Jeśli tak to status jego konta ustawiany jest jako nieaktywny

DELIMITER  //

CREATE PROCEDURE check_if_delayed()
BEGIN
    DECLARE n INT DEFAULT 0;
    DECLARE i INT DEFAULT 0;
    DECLARE delayedDays INT;
    DECLARE userId tinyint;

    SELECT COUNT(movie_id) FROM rentals INTO n;
    SET i=0;
    WHILE i<n DO
        SET delayedDays = (SELECT (DATE(NOW()) - rentals.movie_rented_date) FROM rentals
            LIMIT i,1);
        IF delayedDays > 14 THEN
            SET userId = (SELECT client_id FROM rentals LIMIT i,1);
            UPDATE users SET if_active = 0 WHERE client_id = userId;
        end if;
      SET i = i + 1;
    END WHILE;

end //

DELIMITER ;

-- Procedura do dodawanie reżysera do bazy danych

DELIMITER  //

CREATE PROCEDURE add_director(IN Name varchar(64), IN Surname varchar(64))
BEGIN
    INSERT INTO directors (first_name, last_name) VALUES (Name, Surname);
end //

DELIMITER ;


-- -------------------------------------------------------------------
-- Wyzwalacze -------------------------------------------------------
-- -------------------------------------------------------------------

-- Wyzwalacz usuwający adres z bazy danych, który nie jest już
-- przypisany do żadnego użytkownika po usunięciu użytkownika
-- z tym adresem

DELIMITER //

CREATE TRIGGER delete_addressIf
    AFTER DELETE
    ON users
    FOR EACH ROW
    BEGIN
        DECLARE addressId smallint;

        SET addressId = NULL;
        SET addressId = (SELECT u.address_id FROM users AS u WHERE u.address_id = OLD.address_id);

        IF addressId IS NULL THEN
            DELETE FROM addresses WHERE addresses.address_id = OLD.address_id;
        end if;

end //

DELIMITER ;

-- Wyzwalacz usuwający reżysera z bazy danych, który nie jest już
-- przypisany do żadnego filmu po usunięciu filmu z tym reżyserem

DELIMITER //

CREATE TRIGGER delete_directorIf
    AFTER DELETE
    ON movies
    FOR EACH ROW
    BEGIN
        DECLARE directorId smallint;

        SET directorId = NULL;
        SET directorId = (SELECT director_id FROM movies AS m WHERE m.director_id = OLD.director_id);

        IF directorId IS NULL THEN
            DELETE FROM directors WHERE directors.director_id = OLD.director_id;
        end if;

end //

DELIMITER ;

-- Wyzwalacz, który ustawia użytkownika jako aktywnego
-- jesli oddał już wszytskie filmy. Zmiana będzie widoczna
-- jeśli uzytkownik był wcześniej nieakywny.

DELIMITER //

CREATE TRIGGER update_activeIf
    AFTER DELETE
    ON rentals
    FOR EACH ROW
    BEGIN
        DECLARE userId smallint;

        SET userId = NULL;
        SET userId = (SELECT client_id FROM rentals AS r WHERE r.client_id = OLD.client_id);

        IF userId IS NULL THEN
            UPDATE users SET if_active = 1 WHERE client_id = OLD.client_id;
        end if;

end //

DELIMITER ;
