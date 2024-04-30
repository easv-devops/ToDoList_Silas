import { Selector } from 'testcafe';

fixture `Add Task`
    .page `http://167.86.105.61:5001/todolist`
    .pageLoadTimeout(5000)
    .retryTestPages(true);

test('Add Task', async t => {
    const inputSelector = Selector(".add-task-text");

    // Wait for the input element to appear in the DOM
    await t.waitForSelector(inputSelector, { timeout: 5000 });

    // Find the add-task-text input and set the value to "Test Task"
    await t.typeText(inputSelector, "Test Task");

    // Click the add-task-button button
    await t.click(Selector(".add-task-button"));

    // Assert that the task was added to the list by checking through task class values
    await t.expect(Selector(".task").withText("Test Task").exists).ok();
});