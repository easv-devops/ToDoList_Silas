CREATE TABLE History (
    id INT AUTO_INCREMENT PRIMARY KEY,
    item_id INT NOT NULL,
    created_date DATE NOT NULL,
    text VARCHAR(255) NOT NULL,

    FOREIGN KEY (item_id) REFERENCES Items (id) ON DELETE CASCADE
);