import { Selector } from 'testcafe';

fixture `To-Do List`
    .page `http://167.86.105.61:5001/todolist`;

test('Add Task', async t => {
    // Find the add-task-text input and set the value to "Test Task"
    await t.typeText(Selector(".add-task-text"), "Test Task");
    
    // Click the add-task-button button
    await t.click(Selector(".add-task-button"));
    
    // Assert that the task was added to the list by checking through task class values
    await t.expect(Selector(".task").withText("Test Task").exists).ok();
});

test('Mark Task', async t => {
    // Find task-checkbox and click it
    await t.click(Selector(".task").withText("Test Task").find(".task-checkbox"));

    // Assert that the task was marked by checking through task class values and checking for the checkbox being checked
    await t.expect(Selector(".task").withText("Test Task").find(".task-checkbox").checked).ok();
});

test('Delete Task', async t => {
    // Click the delete-task-button button
    await t.click(Selector(".task").withText("Test Task").find(".task-button"));

    // Assert that the task was deleted from the list by checking through task class values
    await t.expect(Selector(".task").withText("Test Task").exists).notOk();
});