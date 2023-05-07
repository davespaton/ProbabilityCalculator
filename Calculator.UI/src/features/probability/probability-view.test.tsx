import {render, screen, fireEvent} from '@testing-library/react'
import '@testing-library/jest-dom'
import ProbabilityView from './probability-view'
import axios from 'axios';

jest.mock('axios');
const mockedAxios = axios as jest.Mocked<typeof axios>;

describe('ProbabilityView', () => {

    beforeEach(() => {
        mockedAxios.get.mockClear();
    })

    test('renders inputs and buttons', () => {

        // Arrange
        render(<ProbabilityView />);

        // Act
        screen.getByLabelText('Probability A');
        screen.getByLabelText('Probability B');

        expect(screen.getByText<HTMLButtonElement>('Either')).not.toBeDisabled();
        expect(screen.getByText<HTMLButtonElement>('CombinedWith')).not.toBeDisabled();
    });

    test('invalid values disables buttons', () => {

        // Arrange
        render(<ProbabilityView />);

        // Act
        const probabilityA = screen.getByLabelText<HTMLInputElement>('Probability A');
        const eitherButton = screen.getByText<HTMLButtonElement>('Either');
        const combinedWithButton = screen.getByText<HTMLButtonElement>('CombinedWith');

        fireEvent.change(probabilityA, { target: { value: "10" } });

        // Assert
        expect(eitherButton).toBeDisabled();
        expect(combinedWithButton).toBeDisabled();

    });

    test('valid request renders result', async () => {

        // arrange
        mockedAxios.get.mockResolvedValue({
            data: 0.75
        });

        render(<ProbabilityView />);
        const eitherButton = screen.getByText<HTMLButtonElement>('Either');
        
        // Act
        fireEvent.click(eitherButton);

        // Assert
        const result = await screen.findByTestId('result');
        expect(result).toHaveTextContent('0.75');
    });

});