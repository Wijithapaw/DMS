import { DMS.WebPage } from './app.po';

describe('dms.web App', () => {
  let page: DMS.WebPage;

  beforeEach(() => {
    page = new DMS.WebPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
