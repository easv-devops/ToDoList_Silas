import { Selector } from 'testcafe';

fixture `Delete Task`
    .page `http://167.86.105.61:5001/todolist`;

test('Delete Task', async t => {
    // Click the delete-task-button button
    await t.click(Selector(".task").withText("Test Task").find(".task-button"));
    
    // Assert that the task was deleted from the list by checking through task class values
    await t.expect(Selector(".task").withText("Test Task").exists).notOk();
});