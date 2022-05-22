delimiter //
create trigger age_verify
before insert on pracownik
for each row 
if new.RokUrodzenia < 1950 then set new.RokUrodzenia = 0;
end if; //

delimiter //
create trigger wage_verify
before insert on pracownik
for each row 
if new.Wynagrodzenie < 2400 then set new.Wynagrodzenie = 2400; -- najnizsza krajowa netto
end if; //

delimiter //
create trigger bool_verify
before insert on potrawa
for each row 
if new.Czy_Gotowa > 1 then set new.Czy_Gotowa = 1;
end if; //