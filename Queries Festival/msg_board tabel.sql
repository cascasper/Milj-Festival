CREATE TABLE msg_board (
    msg_id serial PRIMARY KEY,
    besked VARCHAR(255) NOT NULL,
    afsender VARCHAR(255) NOT NULL,
    tidspunkt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);