import { FinalspotsPage } from './app.po';

describe('finalspots App', () => {
  let page: FinalspotsPage;

  beforeEach(() => {
    page = new FinalspotsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
