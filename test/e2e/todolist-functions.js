import { Selector } from 'testcafe';

let randomInt = getRandomInt();
let textContent = "Test Task " + randomInt;

fixture `To-Do List`
    .page `http://167.86.105.61:5001/todolist`;

test("Add Task", async t => {
    await t.wait(1000)
    await t.typeText(Selector(".add-task-text"), textContent);
    await t.click(Selector(".add-task-button"));

    await t.wait(1000)
    await t.expect(Selector(".task").find(".task-text").value).contains(textContent);
});

test("Mark Task", async t => {
    await t.wait(1000)
    await t.click(Selector(".task").find(".task-checkbox"));

    await t.wait(1000)
    await t.expect(Selector(".task").find(".task-checkbox").checked).ok();
});

test("Delete Task", async t => {
    await t.wait(1000)
    await t.click(Selector(".task").find(".task-button"));

    await t.wait(1000)
    await t.expect(Selector(".task").find(".task-text").value).notContains(textContent);
});

function getRandomInt() {
    return Math.floor(Math.random() * 100) + 1;
}