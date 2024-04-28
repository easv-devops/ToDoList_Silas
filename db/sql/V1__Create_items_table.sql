CREATE TABLE Items (
    id INT AUTO_INCREMENT PRIMARY KEY,
    text VARCHAR(255) NOT NULL,
    is_completed BOOL NOT NULL
    created_date DATE NOT NULL,
    completed_date DATE NOT NULL
);