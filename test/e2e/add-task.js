import { Selector } from 'testcafe';

fixture `Add Task`
    .page `http://167.86.105.61:5001/todolist`;

test('Add Task', async t => {
    // Find the add-task-text input and set the value to "Test Task"
    await t.typeText(Selector(".add-task-text"), "Test Task");
    
    // Click the add-task-button button
    await t.click(Selector(".add-task-button"));
    
    // Assert that the task was added to the list by checking through task class values
    await t.expect(Selector(".task").withText("Test Task").exists).ok();
});