
type ProbabilityButtonProps = {
    isDisabled: boolean;
    onClick: () => void;
    text: 'Either' | 'CombinedWith';
}

export const ProbabilityButton = (props: ProbabilityButtonProps) => {
    const { isDisabled, onClick, text } = props;
    return <button
        className='bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded disabled:opacity-50 disabled:cursor-not-allowed'
        disabled={isDisabled} 
        onClick={onClick}>{text}
    </button>
}