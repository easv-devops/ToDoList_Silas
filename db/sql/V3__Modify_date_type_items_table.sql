ALTER TABLE Items
    MODIFY created_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    MODIFY completed_date DATETIME;